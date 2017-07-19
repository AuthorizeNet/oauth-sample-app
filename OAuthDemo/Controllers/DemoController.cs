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
            System.Diagnostics.Debug.WriteLine(client);

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: client.GrantType, clientId: client.Id, code: client.Code, clientSecret: client.Secret, platform: client.platform);
                //System.Diagnostics.Debug.WriteLine(response.ToJson());
                client.Step3Response = response.ToJson();
                client.RefreshToken = response.RefreshToken;
            }
            catch
            {
                client.Step3Response = OAuthDemo.Models.Demo.RetrieveErrorResponse;
            }

            return View("Index", client);
        }

        public ActionResult RefreshAccessToken(OAuthDemo.Models.Demo client)
        {
            ModelState.Clear();

            System.Diagnostics.Debug.WriteLine(client);

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: client.GrantType, clientId: client.Id, refreshToken: client.RefreshToken);
                //System.Diagnostics.Debug.WriteLine(response.ToJson());
                client.Step5Response = response.ToJson();
            }
            catch
            {
                client.Step5Response = OAuthDemo.Models.Demo.RefreshErrorResponse;
            }

            return View("Index", client);
        }

        public ActionResult RedirectRevokePermissions()
        {
            return Redirect(OAuthDemo.Models.Demo.RevokePermissionsUrl);
        }
    }
}