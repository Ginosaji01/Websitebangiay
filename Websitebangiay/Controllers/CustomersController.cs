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
    public class CustomersController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

		// GET: Customers
		public ActionResult Index()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			List<Customer> customers = new List<Customer>();

			foreach (Customer c in db.Customers)
			{
				if (c.isDelete == false)
				{
					customers.Add(c);
				}
			}

			return View(customers);
		}

		// GET: Customers/Details/5
		public ActionResult Details(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fullName,address,email,phone,note")] Customer customer)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();

			var lastCus = db.Customers.OrderByDescending(c => c.Id).FirstOrDefault();
			if (lastCus == null)
			{
				customer.Id = 1;
			}
			else
			{
				customer.Id = lastCus.Id + 1;
			}

			customer.isDelete = false;

			if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fullName,address,email,phone,note,isDelete")] Customer customer)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			Customer customer = db.Customers.Find(id);
			customer.isDelete = true;

			foreach (Bill b in db.Bills)
			{
				if (b.id_customer == customer.Id)
				{
					b.isDelete = true;

					foreach (Bill_Detail bd in db.Bill_Details)
					{
						if (bd.id_bill == b.Id)
						{
							bd.isDelete = true;
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
