using HtmlAgilityPack;
using Parse.Manage;
using Parse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parse.Controllers
{
    public class SiteController : Controller
    {
        ParseContext db = new ParseContext();

        public ActionResult GetSite()
        {
            var model = new Site();

            return PartialView("_Site", model);
        }

        [HttpPost]
        public string GetSite(Site model)
        {
            string result = null;
            if (ModelState.IsValid)
            {
                string siteName = model.Name;
                string siteForParse = GetProduct(siteName);
                result = siteForParse;
            }
            return result;
        }

        public string GetProduct(string name)
        {
            CpvProduct product = new CpvProduct();
            string result = null;
            if (product.ParseSite == name)
            {
                CpvProductManage manage = new CpvProductManage();
                manage.Parse(product.NameSite);
                result = "Operation was successfully completed";
            }
            else
            {
                result = "You can only distribute the site ligazakon.ua";
            }
            return result;
        }
    }
}