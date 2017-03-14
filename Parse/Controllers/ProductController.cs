using PagedList;
using Parse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parse.Controllers
{
    public class ProductController : Controller
    {
        ParseContext db = new ParseContext();

        public ActionResult List()
        {
            return View(db.CpvProducts);
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            CpvProduct product = db.CpvProducts.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProduct(CpvProduct product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CpvProduct product)
        {
            db.CpvProducts.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CpvProduct product = db.CpvProducts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CpvProduct product = db.CpvProducts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.CpvProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}