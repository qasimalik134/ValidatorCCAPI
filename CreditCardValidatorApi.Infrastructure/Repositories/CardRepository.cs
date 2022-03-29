using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CreditCardValidatorApi.Application.Interfaces;
using CreditCardValidatorApi.Core.Common;
using CreditCardValidatorApi.Core.Enums;
using CreditCardValidatorApi.Infrastructure.Helper;

namespace CreditCardValidatorApi.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Utility utility;

        public CardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            utility = Utility.GetInstance;
        }

        /* This Function is responsible for Getting Brand Name as per Valid Card Number provided.
         * Getting Brand Name
         * Issue Date Validation
         * CVC mapping to corresponding Card e.g if AMEX then CVC should be 4.
         * Return Card Brand Name if valid details 
         * Else Returns error message(s)
        */
        public async Task<Response> Add(Core.Entities.Card entity)
        {
            Response response = new Response();
            response.Message = new List<string>();
            DateTime _issueDate;

            try
            {
                CardBrandName _cardbrandname = GetCardBrandName(entity.CardNumber);

                if (!entity.IssueDate.Contains(@"/"))
                {
                    _issueDate = DateTime.ParseExact(entity.IssueDate, "MMyy", CultureInfo.InvariantCulture);

                }

                else
                {
                    _issueDate = entity.IssueDate.Length > 5 ? DateTime.ParseExact(entity.IssueDate, "MM/yyyy", CultureInfo.InvariantCulture):
                                                                _issueDate = DateTime.ParseExact(entity.IssueDate, "MM/yy", CultureInfo.InvariantCulture);
                    
                }

                if (!IsValidIssueDate(_issueDate))
                {
                    response.Message.Add("Card is Expired.");
                    response.Status = "Validation Completed Successfully.";
                }

                if (_cardbrandname != CardBrandName.Others)
                {
                    Regex _dgtthreeCVC = new Regex (utility.GetRegex("Three"));
                    Regex _dgtfourCVC = new Regex (utility.GetRegex("Four"));

                    if ((_cardbrandname == CardBrandName.AmericanExpress) && !_dgtfourCVC.IsMatch(entity.CVC))
                    {
                        response.Message.Add("Invalid CVC for " + _cardbrandname);
                        response.Status = "Successful operation but not Validated against provided details.";
                    }
                    else if ((_cardbrandname == CardBrandName.Visa || _cardbrandname == CardBrandName.MasterCard) && !_dgtthreeCVC.IsMatch(entity.CVC)) 
                    {
                        response.Message.Add("Invalid CVC for " + _cardbrandname);
                        response.Status = "Successful operation but not Validated against provided details.";
                    }
                    else
                    {
                        response.Message.Add("Card Validated for " + _cardbrandname);
                        response.Status = "Validation Successful for provided card details.";
                    }
                }
                else
                {
                    response.Message.Add("Card Name not determined.");
                    response.Status = "Card Brand name not determined";
                }

                

                response.Data =  CardType.Credit_Card.ToString() + " identified as "+ _cardbrandname;
            }
            catch (Exception ex)
            {
                response = utility.OperationFailed(ex.Message);
            }

            return response;
        }

        /* 
        * Validate Date
        *Issue Date never Greater then Current Date
        *Issue should be Greater from four years back
         */
        public bool IsValidIssueDate(DateTime _IssueDate)
        {
            bool result = true;
            return result = DateTime.Now.AddYears(-4) > _IssueDate || _IssueDate > DateTime.Now ? false : true;
        }
        /* 
         * Map Card Brand Name as per REGEX
         */
        public CardBrandName GetCardBrandName(string CardNumber)
        {
            CardNumber = CardNumber.Replace(" ","");
            Regex RegexAmericanExpress = new Regex(utility.GetRegex("Amex"));
            Regex RegexVisaCard = new Regex(utility.GetRegex("Visa"));
            Regex RegexMasterCard = new Regex(utility.GetRegex("Master"));

            if (RegexVisaCard.IsMatch(CardNumber))
                return CardBrandName.Visa;
            else if (RegexMasterCard.IsMatch(CardNumber))
                return CardBrandName.MasterCard;
            else if (RegexAmericanExpress.IsMatch(CardNumber))
                return CardBrandName.AmericanExpress;
            else
                return CardBrandName.Others;
        }

        public async Task<Response> ValProp(Core.Entities.Card entity)
        {
            Response response = new Response();
            List<Error> messages = new List<Error>();
            try
            {
                if (string.IsNullOrEmpty(entity.CardOwner))
                {
                    Error error = new Error();
                    error.Message = "'Card Owner' must not be empty.";
                    error.PropertyName = "CardOwner";
                    messages.Add(error);
                }
                if (string.IsNullOrEmpty(entity.CardNumber))
                {
                    Error error = new Error();
                    error.Message = "Invalid Card Number.";
                    error.PropertyName = "CardNumber";
                    messages.Add(error);
                }
                if (string.IsNullOrEmpty(entity.IssueDate))
                {
                    Error error = new Error();
                    error.Message = "'Issue Date' is not in the correct format.";
                    error.PropertyName = "IssueDate";
                    messages.Add(error);
                }
                if (string.IsNullOrEmpty(entity.CVC))
                {
                    Error error = new Error();
                    error.Message = "Invalid CVC.";
                    error.PropertyName = "CVC";
                    messages.Add(error);
                }
            }
            catch (Exception ex)
            {
                response = utility.OperationFailed(ex.Message);
            }
            response.ErrorMessages = messages;

            return response;

        }
    }
}
