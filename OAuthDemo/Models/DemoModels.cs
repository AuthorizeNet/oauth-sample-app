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
        public static string RevokePermissionsUrl = "https://sandbox.authorize.net/UI/themes/sandbox/Settings/ResellerDelegation.aspx";


        public Demo()
        {
            Id = "4dp5b7gRqk";
            Secret = "fa3a5b16753d09b24bb44243605a4a98";
            RedirectUri = "https://developer.authorize.net/api/reference/index.html";
            Scope = "read,write";
            State = "someValue";
            Sub = "oauth";
            updateRedirectMerchantUrl();
            GrantType = "authorization_code";
            platform = 2;
        }

        // Step 1
        public string Id { get; set; }
        public string Secret { get; set; }

        // Step 2
        public string RedirectUri { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
        public string Sub { get; set; }
        public string RedirectMerchantUrl;
        public void updateRedirectMerchantUrl()
        {
            RedirectMerchantUrl = "https://sandbox.authorize.net/oauth/authorize" +
                "?" + "client_id=" + Id +
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

        // Step 5
        public string RefreshToken { get; set; }
        public string Step5Response { get; set; }

        override public string ToString()
        {   
            return "\nId: " + Id + 
                "\nSecret: " + Secret + 
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