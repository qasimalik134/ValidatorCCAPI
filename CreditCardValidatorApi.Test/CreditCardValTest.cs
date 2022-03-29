using Xunit;

using CreditCardValidatorApi.Api.Controllers;
using CreditCardValidatorApi.Application;
using CreditCardValidatorApi.Core.Entities;
using CreditCardValidatorApi.Infrastructure.Repositories;
using CreditCardValidatorApi.Application.Features.Card.Commands;


namespace CreditCardValidatorApi.Test
{
    public class CreditCardValTest
    {
        CardRepository ccValControl;

        public CreditCardValTest()
        {
            ccValControl = new CardRepository(null);
        }


        /* Test Case 
         * for missing
         * Card Holder details */

        [Fact]
        public void IsCardHolderNameMissing()
        {
            //Tesing Data
            Card cardetail = new Card
            {
                CardOwner = "",
                CardNumber = "349490997848836",
                IssueDate = "1224",
                CVC = "1234"
            };

            //Arrange
            var response = ccValControl.ValProp(cardetail);

            //Assert
            Assert.Equal("'Card Owner' must not be empty.", response.Result.ErrorMessages[0].Message);

        }

        /* Test Case 
    * for missing
    * Card Number details */
        [Fact]

        public void IsCardNumberMissing()
        {
            //Tesing Data
            Card cardetail = new Card
            {
                CardOwner = "QASIM",
                CardNumber = "",
                IssueDate = "1224",
                CVC = "1234"
            };

            //Arrange
            var response = ccValControl.ValProp(cardetail);

            //Assert
            Assert.Equal("Invalid Card Number.", response.Result.ErrorMessages[0].Message);

        }
        /* Test Case 
         * for missing
         * Issue Date */
        [Fact]
        public void IsIssueDateMissing()
        {
            //Tesing Data
            Card cardetail = new Card
            {
                CardOwner = "QASIM",
                CardNumber = "349490997848836",
                IssueDate = "",
                CVC = "123"
            };

            //Arrange
            var response = ccValControl.ValProp(cardetail);

            //Assert
            Assert.Equal("'Issue Date' is not in the correct format.", response.Result.ErrorMessages[0].Message);

        }
        /* Test Case 
         * for missing
         * CVC */
        [Fact]
        public void IsCVCMissing()
        {
            //Tesing Data
            Card cardetail = new Card
            {
                CardOwner = "QASIM",
                CardNumber = "349490997848836",
                IssueDate = "1224",
                CVC = ""
            };

            //Arrange
            var response = ccValControl.ValProp(cardetail);

            //Assert
            Assert.Equal("Invalid CVC.", response.Result.ErrorMessages[0].Message);

        }
        /* Test Case 
         * for missing
         * All CardDetails */
        [Fact]
        public void AllCardDetailsMissing()
        {
            //Tesing Data
            Card cardetail = new Card
            {
                CardOwner = "",
                CardNumber = "",
                IssueDate = "",
                CVC = ""
            };

            //Arrange
            var response = ccValControl.ValProp(cardetail);

            //Assert
            foreach (var message in response.Result.ErrorMessages)
            {
                if (message.Message.Contains("CVC"))
                {
                    Assert.Equal("Invalid CVC.", message.Message);
                }
                else if (message.Message.Contains("Card Number"))
                {
                    Assert.Equal("Invalid Card Number.", message.Message);
                }
                else if (message.Message.Contains("Issue Date"))
                {
                    Assert.Equal("'Issue Date' is not in the correct format.", message.Message);
                }
                else if (message.Message.Contains("Card Owner"))
                {
                    Assert.Equal("'Card Owner' must not be empty.", message.Message);
                }
            }
        }
        /* Test Case 
         * with Valid
         * Master Card Details*/
        [Fact]
        public void IsCardDetailsValidForMasterCard()
        {


            //Tesing Data
            Card cardetail = new Card()
            {
                CardOwner = "Alex Hales",
                CardNumber = "5122 1737 4451 7464",
                IssueDate = "12/2020",
                CVC = "111"
            };
            //Act
            var response = ccValControl.Add(cardetail);

            // Assert
            Assert.Equal("Card Validated for MasterCard", response.Result.Message[0]);
        }
        /* Test Case 
         * with Valid
         * AMEX Details*/
        [Fact]
        public void IsCardDetailsValidForAmex()
        {


            //Tesing Data
            Card cardetail = new Card()
            {
                CardOwner = "Williams",
                CardNumber = "349490997848836",
                IssueDate = "12/2020",
                CVC = "111"
            };
            //Act
            var response = ccValControl.Add(cardetail);

            // Assert
            Assert.Equal("Card Validated for AmericanExpress", response.Result.Message[0]);
        }

        /* Test Case 
         * with InValid
         * AMEX CVC code*/
        [Fact]
        public void IsCVCInValidForAmex()
        {


            //Tesing Data
            Card cardetail = new Card()
            {
                CardOwner = "Williams",
                CardNumber = "349490997848836",
                IssueDate = "12/2020",
                CVC = "1112"
            };
            //Act
            var response = ccValControl.Add(cardetail);

            // Assert
            Assert.Equal("Invalid CVC for AmericanExpress", response.Result.Message[0]);
        }
        /* Test Case 
         * with InValid
         * Issue Date*/
        [Fact]
        public void IsInValidIssueDate()
        {


            //Tesing Data
            Card cardetail = new Card()
            {
                CardOwner = "Williams",
                CardNumber = "349490997848836",
                IssueDate = "12/2024",
                CVC = "1112"
            };
            //Act
            var response = ccValControl.Add(cardetail);

            // Assert
            Assert.Equal("Card is Expired.", response.Result.Message[0]);
        }
        /* Test Case 
         * with Valid
         * Visa Card Details*/
        [Fact]
        public void IsCardDetailsValidForVisaCard()
        {


            //Tesing Data
            Card cardetail = new Card()
            {
                CardOwner = "Thomas",
                CardNumber = "4551531114220030",
                IssueDate = "12/2020",
                CVC = "111"
            };
            //Act
            var response = ccValControl.Add(cardetail);

            // Assert
            Assert.Equal("Card Validated for Visa", response.Result.Message[0]);
        }
    }

}

