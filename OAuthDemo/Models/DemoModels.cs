using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OAuthDemo.Models
{
    // WARNING: This is a demonstration application for educational purposes only
    // OAuth credentials are stored in plaintext in the database to simplify the demo
    // PRODUCTION APPLICATIONS MUST encrypt sensitive data at rest using:
    // - ASP.NET Data Protection API
    // - SQL Server column-level encryption
    // - Azure Key Vault or similar key management service
    public class Demo
    {
        public const string RetrieveErrorResponse = "Error Retrieving the Access Token";
        public const string RefreshErrorResponse = "Error Refreshing the Access Token";
        public const string APICallErrorResponse = "Error Calling ANet API";
        public static readonly string RevokePermissionsUrl;

        static Demo()
        {
            //TODO: finish other responses
            RevokePermissionsUrl = ConfigurationManager.AppSettings["revokeUrl"];
        }

        public Demo()
        {
            // ClientId / ClientSecret must come from Web.config <appSettings> (use placeholders
            // [YOUR_CLIENT_ID] / [YOUR_CLIENT_SECRET] until you fill in your own sandbox values).
            // Obtain values from the Authorize.Net Sandbox portal — see README for the procedure.
            ClientId = ConfigurationManager.AppSettings["ClientId"] ?? "";
            ClientSecret = ConfigurationManager.AppSettings["ClientSecret"] ?? "";
            RedirectUri = "https://developer.authorize.net/api/reference/index.html";
            Read = true;
            Write = true;
            State = "someValue";
            Sub = "oauth";
            updateRedirectMerchantUrl();
            GrantType = "authorization_code";
            platform = 2;
            CardNumber = "5424000000000015";
            ExpirationDate = DateTime.Now.AddYears(1);
            Amount = Convert.ToDecimal(DateTime.Now.ToString("mm.ss"));
            TransactionId = "60027723161";
        }
        public Demo(string InputId) : this()
        {
            Id = InputId;
        }

        public string Id { get; set; }

        // Step 1
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        // Step 2
        public string RedirectUri { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }

        public string State { get; set; }
        public string Sub { get; set; }
        public string RedirectMerchantUrl { get; set; }
        public void updateRedirectMerchantUrl()
        {
            string scope;
            if (Read && Write)
                scope = "read,write";
            else if (Read)
                scope = "read";
            else
                scope = "write";

            RedirectMerchantUrl = "https://sandbox.authorize.net/oauth/authorize" +
                "?" + "client_id=" + ClientId +
                "&" + "redirect_uri=" + RedirectUri +
                "&" + "scope=" + scope +
                "&" + "state=" + State +
                "&" + "sub=" + Sub;
        }

        // Step 3
        public string GrantType { get; set; }
        public string Code { get; set; }
        public string Step3Response { get; set; }
        public int? platform { get; set; }
        // Step 4
        public string AccessToken { get; set; }
        public string CardNumber { get; set; }
        [DisplayFormat(DataFormatString = "{MM/yy}",
               ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string Step4Response { get; set; }

        // Step 5
        public string RefreshToken { get; set; }
        public string Step5Response { get; set; }

        override public string ToString()
        {   
            return "\nId: " + ClientId + 
                "\nSecret: " + ClientSecret + 
                "\nRedirectUri: " + RedirectUri +
                "\nRead: " + Read +
                "\nWrite: " + Write +
                "\nState: " + State + 
                "\nSub: " + Sub + 
                "\nGrantType: " + GrantType + 
                "\nCode: " + Code + 
                "\nRefreshToken: " + RefreshToken +
                "\n";
        }
    }
}
