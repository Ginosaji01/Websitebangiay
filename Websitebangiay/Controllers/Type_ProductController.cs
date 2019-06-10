using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class Type_ProductController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

        // GET: Type_Product
        public ActionResult Index()
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			return View(db.Type_Products.ToList());
        }

        // GET: Type_Product/Details/5
        public ActionResult Details(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Product type_Product = db.Type_Products.Find(id);
            if (type_Product == null)
            {
                return HttpNotFound();
            }
            return View(type_Product);
        }

        // GET: Type_Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,description,image,link")] Type_Product type_Product)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Type_Products.Add(type_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_Product);
        }

        // GET: Type_Product/Edit/5
        public ActionResult Edit(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Product type_Product = db.Type_Products.Find(id);
            if (type_Product == null)
            {
                return HttpNotFound();
            }
            return View(type_Product);
        }

        // POST: Type_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,description,image,link")] Type_Product type_Product)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Entry(type_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_Product);
        }

        // GET: Type_Product/Delete/5
        public ActionResult Delete(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Product type_Product = db.Type_Products.Find(id);
            if (type_Product == null)
            {
                return HttpNotFound();
            }
            return View(type_Product);
        }

        // POST: Type_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			Type_Product type_Product = db.Type_Products.Find(id);
            db.Type_Products.Remove(type_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		public JsonResult GetAllTypeProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			var allTypeProduct = db.Type_Products.ToList();
			return Json(allTypeProduct, JsonRequestBehavior.AllowGet);
		}
    }
}
