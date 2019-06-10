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
    public class BillsController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

		// GET: Bills
		public ActionResult Index()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			List<Bill> bills = new List<Bill>();
			foreach (Bill b in db.Bills)
			{
				if (b.isDelete == false)
				{
					bills.Add(b);
				}
			}

			return View(bills);
		}

		// GET: Bills/Details/5
		public ActionResult Details(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			ViewBag.id_customer = new SelectList(db.Customers, "Id", "fullName");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_customer,date_order,total,note,status,isDelete")] Bill bill)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_customer = new SelectList(db.Customers, "Id", "fullName", bill.id_customer);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_customer = new SelectList(db.Customers, "Id", "fullName", bill.id_customer);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_customer,date_order,total,note,status,isDelete")] Bill bill)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_customer = new SelectList(db.Customers, "Id", "fullName", bill.id_customer);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			Bill bill = db.Bills.Find(id);
			bill.isDelete = true;

			foreach (Bill_Detail bd in db.Bill_Details)
			{
				if (bd.id_bill == bill.Id)
				{
					bd.isDelete = true;
				}
			}

			foreach (Customer cus in db.Customers)
			{
				if (cus.Id == bill.id_customer)
				{
					cus.isDelete = true;
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
