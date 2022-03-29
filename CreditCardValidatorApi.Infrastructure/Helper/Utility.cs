using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CreditCardValidatorApi.Core.Common;
using CreditCardValidatorApi.Core.Enums;

namespace CreditCardValidatorApi.Infrastructure.Helper
{
    public sealed class Utility
    {

        private static Utility instance = null;

        public static Utility GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Utility();
                return instance;
            }
        }

        private Utility()
        {
        }

        //Method for Successfull Operation
        public Response OperationSuccess()
        {
            Response response;
            try
            {
                response = new Response
                {
                    Status = ResponseStatus.Success.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            return response;
        }

        public Response OperationFailed(string message)
        {
            Response response = new Response();
            response.ErrorMessages = new List<Error>();
            try
            {

                response.Status = ResponseStatus.Failed.ToString();
                response.ErrorMessages.Add(new Error
                {
                    PropertyName = "Exception",
                    Message = message
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);

            }
            return response;
        }


        public DateTime GetDateTime()
        {
            try
            {
                string strDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt", new System.Globalization.CultureInfo("en-US"));
                return DateTime.ParseExact(strDate, "dd/MM/yy HH:mm:ss tt", new System.Globalization.CultureInfo("en-US"));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.StackTrace);
            }
        }
        /*
        . Validation(s) corresponding to Card Brand Name(AMEX,VISA,MASTER)
        . Validation(s) corresponding to CVC digits (3 or 4)

         */
        public string GetRegex(string _regexName)
        {
            // Regex Expressions for Cards
            string regex = "";
            switch (_regexName)
            {
                case "Amex":
                    regex = @"^3[47][0-9]{13}$";
                    break;
                case "Visa":
                    // code block
                    regex = @"^4[0-9]{12}(?:[0-9]{3})?$";
                    break;
                case "Master":
                    // code block
                    regex = @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$";
                    break;
                case "Three":
                    regex = (@"^\d{3}$");
                    break;
                case "Four":
                    regex = (@"^\d{4}$");
                    break;
                default:
                    // code block
                    break;
            }

            return regex;

        }


    }
}
