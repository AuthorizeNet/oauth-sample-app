using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace net.authorize.sample
{
    public class GetTransactionDetails
    {
        public static String Run(String AccessToken, string transactionId)
        {
            Console.WriteLine("Get transaction details sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                ItemElementName = ItemChoiceType.accessToken,
                Item = AccessToken
            };

            var request = new getTransactionDetailsRequest();
            request.transId = transactionId;

            // instantiate the controller that will call the service
            var controller = new getTransactionDetailsController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();
            StringBuilder toReturn = new StringBuilder();

            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.transaction == null)
                    return "response transaction was null";

                toReturn.AppendLine("Transaction Id: " + response.transaction.transId);
                toReturn.AppendLine("Transaction type: " + response.transaction.transactionType);
                toReturn.AppendLine("Transaction status: " + response.transaction.transactionStatus);
                toReturn.AppendLine("Transaction auth amount: " + response.transaction.authAmount);
                toReturn.AppendLine("Transaction settle amount: " + response.transaction.settleAmount);
            }
            else if (response != null)
            {
                toReturn.AppendLine("Error: " + response.messages.message[0].code + "  " +
                                  response.messages.message[0].text);
            }

            return toReturn.ToString();
        }
    }
}
