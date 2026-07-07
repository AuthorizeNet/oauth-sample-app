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
    public static class GetTransactionDetails
    {
        public static String Run(String AccessToken, string transactionId)
        {
            Console.WriteLine("Get transaction details sample");

            // SECURITY: Authentication is set per-request on the request object (not via
            // shared static properties) to prevent race conditions in multi-threaded
            // ASP.NET environments. Environment is passed to Execute() for the same reason.
            var merchantAuthentication = new merchantAuthenticationType()
            {
                ItemElementName = ItemChoiceType.accessToken,
                Item = AccessToken
            };

            var request = new getTransactionDetailsRequest();
            request.merchantAuthentication = merchantAuthentication;
            request.transId = transactionId;

            // instantiate the controller that will call the service
            var controller = new getTransactionDetailsController(request);
            controller.Execute(AuthorizeNet.Environment.SANDBOX);

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
