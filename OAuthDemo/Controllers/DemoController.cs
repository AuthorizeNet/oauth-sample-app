using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;
using OAuthDemo.Models;

namespace OAuthDemo.Controllers
{
    public class DemoController : Controller
    {
        private ApplicationDbContext _context;
        public DemoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Demo
        public ActionResult Index()
        {
            Demo DemoModel = new Demo(Guid.NewGuid().ToString());
            _context.Demos.Add(DemoModel);
            _context.SaveChanges();
            return View(DemoModel);
        }

        public ActionResult RegisterApplication()
        {
            return null;
        }

        // step 2
        public ActionResult RedirectMerchant(Demo InputModel)
        {
            System.Diagnostics.Debug.WriteLine(_context.Demos.ToString());
            var SavedModel = _context.Demos.SingleOrDefault(d => d.Id == InputModel.Id);
            SavedModel.ClientId = InputModel.ClientId;
            SavedModel.RedirectUri = InputModel.RedirectUri;
            SavedModel.Read = InputModel.Read;
            SavedModel.Write = InputModel.Write;
            SavedModel.State = InputModel.State;
            SavedModel.Sub = InputModel.Sub;
            SavedModel.updateRedirectMerchantUrl();

            //System.Diagnostics.Debug.WriteLine(InputModel);
            //System.Diagnostics.Debug.WriteLine(InputModel.RedirectMerchantUrl);

            _context.SaveChanges();
            return Redirect(SavedModel.RedirectMerchantUrl);
        }

        // step 3
        public ActionResult RetrieveAccessToken(Demo InputModel)
        {
            var SavedModel = _context.Demos.SingleOrDefault(d => d.Id == InputModel.Id);
            SavedModel.GrantType = InputModel.GrantType;
            SavedModel.Code = InputModel.Code;
            SavedModel.ClientId = InputModel.ClientId;
            SavedModel.ClientSecret = InputModel.ClientSecret;

            //System.Diagnostics.Debug.WriteLine(InputModel);

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: SavedModel.GrantType, clientId: SavedModel.ClientId, code: SavedModel.Code, clientSecret: SavedModel.ClientSecret, platform: SavedModel.platform);
                //System.Diagnostics.Debug.WriteLine(response.ToJson());
                SavedModel.Step3Response = response.ToJson();
                SavedModel.AccessToken = response.AccessToken;
                SavedModel.RefreshToken = response.RefreshToken;
            }
            catch
            {
                SavedModel.Step3Response = Demo.RetrieveErrorResponse;
            }

            _context.SaveChanges();
            return View("Index", SavedModel);
        }

        // step 4
        public ActionResult ChargeCreditCard(Demo InputModel)
        {
            var SavedModel = _context.Demos.SingleOrDefault(d => d.Id == InputModel.Id);
            SavedModel.AccessToken = InputModel.AccessToken;
            SavedModel.Amount = InputModel.Amount;

            //System.Diagnostics.Debug.WriteLine(client);

            try
            {
                SavedModel.Step4Response = net.authorize.sample.ChargeCreditCard.Run(SavedModel.AccessToken, SavedModel.Amount);
            }
            catch
            {
                SavedModel.Step4Response = Demo.APICallErrorResponse;
            }

            _context.SaveChanges();
            return View("Index", SavedModel);
        }

        // step 5
        public ActionResult RefreshAccessToken(Demo InputModel)
        {
            var SavedModel = _context.Demos.SingleOrDefault(d => d.Id == InputModel.Id);
            SavedModel.ClientId = InputModel.ClientId;
            SavedModel.ClientSecret = InputModel.ClientSecret;
            SavedModel.GrantType = InputModel.GrantType;
            SavedModel.RefreshToken = InputModel.RefreshToken;

            //System.Diagnostics.Debug.WriteLine(client);

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: SavedModel.GrantType, clientId: SavedModel.ClientId, clientSecret: SavedModel.ClientSecret, refreshToken: SavedModel.RefreshToken);
                //System.Diagnostics.Debug.WriteLine(response.ToJson());
                SavedModel.Step5Response = response.ToJson();
            }
            catch
            {
                SavedModel.Step5Response = Demo.RefreshErrorResponse;
            }

            _context.SaveChanges();
            return View("Index", SavedModel);
        }

        public ActionResult RedirectRevokePermissions()
        {
            return Redirect(Demo.RevokePermissionsUrl);
        }
    }
}