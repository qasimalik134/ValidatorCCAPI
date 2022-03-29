using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidatorApi.Core.Enums;

namespace CreditCardValidatorApi.Core.Entities
{
   public class Card
    {
        #region Public Properties
        public string CardOwner { get { return _cardOwner; } set { _cardOwner = value; } }
        public string CardNumber { get { return _cardNumber; } set { _cardNumber = value; } }
        public string IssueDate { get { return _issueDate; } set { _issueDate = value; } }

        public string CVC { get { return _cvc; } set { _cvc = value; } }
        public CardType CardType { get { return _cardType; } set { _cardType = value; } }
        public CardBrandName CardBrandName { get{ return _cardBrandName; } set { _cardBrandName = value; } }

        #endregion

        #region Private Properties
        private string _cardOwner { get; set; }
        private string _cardNumber { get; set; }
        private string _issueDate { get; set; }
        private string _cvc { get; set; }
        private CardType _cardType { get; set; }
        private CardBrandName _cardBrandName { get; set; }
        #endregion
    }
}
