using HtmlAgilityPack;
using Parse.Interface;
using Parse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parse.Manage
{
    public class CpvProductManage : IParser
    {
        ParseContext db = new ParseContext();
        public void Parse(string name)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw = new HtmlWeb();
            doc = hw.Load(name);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(".//*[@id='txtE3']/div/table/tr");
            string result = "";
            List<CpvProduct> entity = new List<CpvProduct>();
            foreach (var item in nodes)
            {
                CpvProduct c = new CpvProduct();
                c.Code = item.SelectSingleNode("td[1]").InnerText;
                c.Title = item.SelectSingleNode("td[2]").InnerText;
                c.TitleEngl = item.SelectSingleNode("td[3]").InnerText;
                result += item.InnerText + Environment.NewLine;
                entity.Add(c);
            }

            foreach (var item in entity)
            {
                db.Entry(item).State = EntityState.Added;
            }
            db.SaveChanges();
        }
    }
}