using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;

namespace net.authorize.sample
{
    public static class ChargeCreditCard
    {
        public static String Run(String AccessToken, String CardNumber, DateTime ExpirationDate, decimal Amount)
        {
            Console.WriteLine("Charge Credit Card Sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                ItemElementName = ItemChoiceType.accessToken,
                Item = AccessToken,
            };

            var creditCard = new creditCardType
            {
                cardNumber = CardNumber,
                expirationDate = ExpirationDate.ToString("MMyy"),
                cardCode = "123"
            };

            var billingAddress = new customerAddressType
            {
                firstName = "John",
                lastName = "Doe",
                address = "123 My St",
                city = "OurTown",
                zip = "99091"
            };

            //standard api call to retrieve response
            var paymentType = new paymentType { Item = creditCard };

            // Add line Items
            var lineItems = new lineItemType[2];
            lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt", quantity = 2, unitPrice = new Decimal(15.00) };
            lineItems[1] = new lineItemType { itemId = "2", name = "snowboard", quantity = 1, unitPrice = new Decimal(450.00) };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

                amount = Amount,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = lineItems
            };
            
            var request = new createTransactionRequest { transactionRequest = transactionRequest };
            
            // instantiate the contoller that will call the service
            var controller = new createTransactionController(request);
            controller.Execute();
            
            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            //validate
            StringBuilder toReturn = new StringBuilder();
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if(response.transactionResponse.messages != null)
                    {
                        toReturn.AppendLine("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        toReturn.AppendLine("Response Code: " + response.transactionResponse.responseCode);
                        toReturn.AppendLine("Message Code: " + response.transactionResponse.messages[0].code);
                        toReturn.AppendLine("Description: " + response.transactionResponse.messages[0].description);
						toReturn.AppendLine("Success, Auth Code : " + response.transactionResponse.authCode);
                    }
                    else
                    {
                        toReturn.AppendLine("Failed Transaction.");
                        if (response.transactionResponse.errors != null)
                        {
                            toReturn.AppendLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            toReturn.AppendLine("Error message: " + response.transactionResponse.errors[0].errorText);
                        }
                    }
                }
                else
                {
                    toReturn.AppendLine("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        toReturn.AppendLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        toReturn.AppendLine("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        toReturn.AppendLine("Error Code: " + response.messages.message[0].code);
                        toReturn.AppendLine("Error message: " + response.messages.message[0].text);
                    }
                }
            }
            else
            {
                toReturn.AppendLine("Null Response.");
            }

            return toReturn.ToString();
        }
    }
}