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
    public class Bill_DetailController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

		// GET: Bill_Detail
		public ActionResult Index()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			List<Bill_Detail> bill_Details = new List<Bill_Detail>();
			foreach (Bill_Detail bd in db.Bill_Details)
			{
				if (bd.isDelete == false)
				{
					bill_Details.Add(bd);
				}
			}
			return View(bill_Details);
		}

		// GET: Bill_Detail/Details/5
		public ActionResult Details(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Details.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Create
        public ActionResult Create()
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			ViewBag.id_bill = new SelectList(db.Bills, "Id", "note");
            ViewBag.id_product = new SelectList(db.Products, "Id", "title");
            return View();
        }

        // POST: Bill_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,quantity,price,id_type,id_bill,id_product,size,isDelete")] Bill_Detail bill_Detail)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Bill_Details.Add(bill_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_bill = new SelectList(db.Bills, "Id", "note", bill_Detail.id_bill);
            ViewBag.id_product = new SelectList(db.Products, "Id", "title", bill_Detail.id_product);
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Details.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bill = new SelectList(db.Bills, "Id", "note", bill_Detail.id_bill);
            ViewBag.id_product = new SelectList(db.Products, "Id", "title", bill_Detail.id_product);
            return View(bill_Detail);
        }

        // POST: Bill_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,quantity,price,id_type,id_bill,id_product,size,isDelete")] Bill_Detail bill_Detail)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
				db.Entry(bill_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bill = new SelectList(db.Bills, "Id", "note", bill_Detail.id_bill);
            ViewBag.id_product = new SelectList(db.Products, "Id", "title", bill_Detail.id_product);
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Details.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            return View(bill_Detail);
        }

        // POST: Bill_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			Bill_Detail bill_Detail = db.Bill_Details.Find(id);
			bill_Detail.isDelete = true;
			foreach (Bill b in db.Bills)
			{
				if (bill_Detail.id_bill == b.Id)
				{
					b.isDelete = true;

					foreach (Customer c in db.Customers)
					{
						if (c.Id == b.id_customer)
						{
							c.isDelete = true;
						}
					}
				}
			}

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
    }
}
