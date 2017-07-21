using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAuthDemo.Models
{
    public class Demo
    {
        public static string RetrieveErrorResponse = "Error Retrieving the Access Token";
        public static string RefreshErrorResponse = "Error Refreshing the Access Token";
        public static string APICallErrorResponse = "Error Calling ANet API";
        public static string RevokePermissionsUrl = "https://sandbox.authorize.net/UI/themes/sandbox/Settings/ResellerDelegation.aspx";


        public Demo()
        {
            ClientId = "4dp5b7gRqk";
            ClientSecret = "fa3a5b16753d09b24bb44243605a4a98";
            RedirectUri = "https://developer.authorize.net/api/reference/index.html";
            Scope = "read,write";
            State = "someValue";
            Sub = "oauth";
            updateRedirectMerchantUrl();
            GrantType = "authorization_code";
            platform = 2;
            Amount = 5.00m;
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
        public string Scope { get; set; }
        public string State { get; set; }
        public string Sub { get; set; }
        public string RedirectMerchantUrl;
        public void updateRedirectMerchantUrl()
        {
            RedirectMerchantUrl = "https://sandbox.authorize.net/oauth/authorize" +
                "?" + "client_id=" + ClientId +
                "&" + "redirect_uri=" + RedirectUri +
                "&" + "scope=" + Scope +
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
        public decimal Amount { get; set; }
        public string Step4Response { get; set; }

        // Step 5
        public string RefreshToken { get; set; }
        public string Step5Response { get; set; }

        override public string ToString()
        {   
            return "\nId: " + ClientId + 
                "\nSecret: " + ClientSecret + 
                "\nRedirectUri: " + RedirectUri + 
                "\nScope: " + Scope + 
                "\nState: " + State + 
                "\nSub: " + Sub + 
                "\nGrantType: " + GrantType + 
                "\nCode: " + Code + 
                "\nRefreshToken: " + RefreshToken +
                "\n";
        }
    }
}