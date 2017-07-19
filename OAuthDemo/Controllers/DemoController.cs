using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace OAuthDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View(new OAuthDemo.Models.Demo());
        }

        public ActionResult RedirectMerchant(OAuthDemo.Models.Demo client)
        {
            System.Diagnostics.Debug.WriteLine(client);
            client.updateRedirectMerchantUrl();
            System.Diagnostics.Debug.WriteLine(client.RedirectMerchantUrl);
            return Redirect(client.RedirectMerchantUrl);
        }

        public ActionResult RetrieveAccessToken(OAuthDemo.Models.Demo client)
        {
            RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
            string grantType = "authorization_code";
            string clientId = "4dp5b7gRqk";
            string code = "novp2e";
            string clientSecret = "fa3a5b16753d09b24bb44243605a4a98";
            string refreshToken = null;
            int? platform = 2;
            var response = instance.GetToken(grantType, clientId, code, clientSecret, refreshToken, platform);
            System.Diagnostics.Debug.WriteLine(response);

            return View("Index", client);
        }
    }
}