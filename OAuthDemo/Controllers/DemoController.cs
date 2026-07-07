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
    // This educational demo is intentionally usable without a login. To still prevent
    // IDOR (one visitor tampering with a Demo record created by another visitor), each
    // Demo is bound to the browser Session that created it, and every action validates
    // that the requested Id belongs to the current session before touching it.
    public class DemoController : Controller
    {
        private const string OwnedDemoIdsKey = "OwnedDemoIds";

        private readonly ApplicationDbContext _context;
        public DemoController()
        {
            _context = new ApplicationDbContext();
        }

        // The set of Demo Ids created by (and therefore owned by) the current session.
        private HashSet<string> OwnedDemoIds
        {
            get
            {
                var owned = Session[OwnedDemoIdsKey] as HashSet<string>;
                if (owned == null)
                {
                    owned = new HashSet<string>();
                    Session[OwnedDemoIdsKey] = owned;
                }
                return owned;
            }
        }

        // Returns the Demo only if it belongs to the current session; otherwise null,
        // so callers can reject the request instead of acting on someone else's record.
        private Demo GetOwnedDemo(string id)
        {
            if (string.IsNullOrEmpty(id) || !OwnedDemoIds.Contains(id))
                return null;
            return _context.Demos.SingleOrDefault(d => d.Id == id);
        }

        // GET: Demo
        public ActionResult Index()
        {
            Demo DemoModel = new Demo(Guid.NewGuid().ToString());
            _context.Demos.Add(DemoModel);
            _context.SaveChanges();
            OwnedDemoIds.Add(DemoModel.Id); // record session ownership for IDOR checks
            return View(DemoModel);
        }

        public ActionResult RegisterApplication()
        {
            return null;
        }

        // step 2
        public ActionResult RedirectMerchant(RedirectMerchantInput input)
        {
            System.Diagnostics.Debug.WriteLine(_context.Demos.ToString());
            var SavedModel = GetOwnedDemo(input.Id);
            if (SavedModel == null)
                return new HttpUnauthorizedResult();
            
            SavedModel.ClientId = input.ClientId;
            SavedModel.RedirectUri = input.RedirectUri;
            SavedModel.Read = input.Read;
            SavedModel.Write = input.Write;
            SavedModel.State = input.State;
            SavedModel.Sub = input.Sub;
            SavedModel.updateRedirectMerchantUrl();

            _context.SaveChanges();
            return Redirect(SavedModel.RedirectMerchantUrl);
        }

        // step 3
        public ActionResult RetrieveAccessToken(RetrieveAccessTokenInput input)
        {
            var SavedModel = GetOwnedDemo(input.Id);
            if (SavedModel == null)
                return new HttpUnauthorizedResult();
            
            SavedModel.GrantType = input.GrantType;
            SavedModel.Code = input.Code;
            SavedModel.ClientId = input.ClientId;
            // WARNING: Demo application only - credentials stored in plaintext for educational purposes
            // PRODUCTION CODE MUST encrypt credentials at rest using ASP.NET Data Protection API or column-level encryption
            SavedModel.ClientSecret = input.ClientSecret;

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: SavedModel.GrantType, clientId: SavedModel.ClientId, code: SavedModel.Code, clientSecret: SavedModel.ClientSecret, platform: SavedModel.platform);
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
        public ActionResult ChargeCreditCard(ChargeCreditCardInput input)
        {
            var SavedModel = GetOwnedDemo(input.Id);
            if (SavedModel == null)
                return new HttpUnauthorizedResult();
            
            SavedModel.AccessToken = input.AccessToken;
            SavedModel.CardNumber = input.CardNumber;
            SavedModel.ExpirationDate = input.ExpirationDate;
            SavedModel.Amount = input.Amount;

            try
            {
                SavedModel.Step4Response = net.authorize.sample.ChargeCreditCard.Run(
                    SavedModel.AccessToken, 
                    SavedModel.CardNumber, 
                    SavedModel.ExpirationDate, 
                    SavedModel.Amount);
            }
            catch
            {
                SavedModel.Step4Response = Demo.APICallErrorResponse;
            }

            _context.SaveChanges();
            return View("Index", SavedModel);
        }

        public ActionResult GetTransactionDetails(GetTransactionDetailsInput input)
        {
            var SavedModel = GetOwnedDemo(input.Id);
            if (SavedModel == null)
                return new HttpUnauthorizedResult();
            
            SavedModel.AccessToken = input.AccessToken;
            SavedModel.TransactionId = input.TransactionId;

            try
            {
                SavedModel.Step4Response = net.authorize.sample.GetTransactionDetails.Run(
                    SavedModel.AccessToken,
                    SavedModel.TransactionId
                    );
            }
            catch
            {
                SavedModel.Step4Response = Demo.APICallErrorResponse;
            }

            _context.SaveChanges();
            return View("Index", SavedModel);
        }

        // step 5
        public ActionResult RefreshAccessToken(RefreshAccessTokenInput input)
        {
            var SavedModel = GetOwnedDemo(input.Id);
            if (SavedModel == null)
                return new HttpUnauthorizedResult();
            
            SavedModel.ClientId = input.ClientId;
            SavedModel.ClientSecret = input.ClientSecret;
            SavedModel.GrantType = input.GrantType;
            SavedModel.RefreshToken = input.RefreshToken;

            try
            {
                RetrievingRefreshingApi instance = new RetrievingRefreshingApi();
                var response = instance.GetToken(grantType: SavedModel.GrantType, clientId: SavedModel.ClientId, clientSecret: SavedModel.ClientSecret, refreshToken: SavedModel.RefreshToken);
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
