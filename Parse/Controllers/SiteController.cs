using HtmlAgilityPack;
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
                result= siteForParse;
            }
            return result;
        }

        public string GetProduct(string name)
        {
            string result = null;
            List<Site> sites = db.Sites.ToList();
            if (sites != null)
            {
                var entityList = sites.Where(x => x.Name == name);
                if (entityList != null)
                {
                    Parse();
                    result = "ok";
                }
                else
                {
                    result = "Now there is no way to parse this site";
                }
            }
            return result;
        }

        public void Parse()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw = new HtmlWeb();
            doc = hw.Load(ProjectConst.NameSite);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(".//*[@id='txtE3']/div/table/tr");
            string result = "";
            List<Product> entity = new List<Product>();
            foreach (var item in nodes)
            {
                Product c = new Product();
                c.Code = item.SelectSingleNode("td[1]").InnerText;
                c.Title = item.SelectSingleNode("td[2]").InnerText;
                c.TitleEngl = item.SelectSingleNode("td[3]").InnerText;
                result += item.InnerText + Environment.NewLine;
                entity.Add(c);
            }

            foreach (var item in entity)
            {
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}