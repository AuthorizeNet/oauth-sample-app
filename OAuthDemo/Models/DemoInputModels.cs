using System;

namespace OAuthDemo.Models
{
    // Input model for RedirectMerchant action
    public class RedirectMerchantInput
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public string State { get; set; }
        public string Sub { get; set; }
    }

    // Input model for RetrieveAccessToken action
    public class RetrieveAccessTokenInput
    {
        public string Id { get; set; }
        public string GrantType { get; set; }
        public string Code { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    // Input model for ChargeCreditCard action
    public class ChargeCreditCardInput
    {
        public string Id { get; set; }
        public string AccessToken { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Amount { get; set; }
    }

    // Input model for GetTransactionDetails action
    public class GetTransactionDetailsInput
    {
        public string Id { get; set; }
        public string AccessToken { get; set; }
        public string TransactionId { get; set; }
    }

    // Input model for RefreshAccessToken action
    public class RefreshAccessTokenInput
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }
    }
}
