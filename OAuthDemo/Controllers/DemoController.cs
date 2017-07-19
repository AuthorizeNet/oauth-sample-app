using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View("Index", client);
        }
    }
}