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
            System.Diagnostics.Debug.WriteLine("called Index");
            System.Diagnostics.Debug.WriteLine("called Index");
            System.Diagnostics.Debug.WriteLine("called Index");
            return View(new OAuthDemo.Models.Demo());
        }

        public ActionResult RedirectMerchant(OAuthDemo.Models.Demo model)
        {
            System.Diagnostics.Debug.WriteLine("called RedirectMerchant");
            System.Diagnostics.Debug.WriteLine("called RedirectMerchant");
            System.Diagnostics.Debug.WriteLine("called RedirectMerchant");
            System.Diagnostics.Debug.WriteLine("called RedirectMerchant");

            System.Diagnostics.Debug.WriteLine(model);
            System.Diagnostics.Debug.WriteLine(model.ToString());

            return View("Index", model); ;
        }
    }
}