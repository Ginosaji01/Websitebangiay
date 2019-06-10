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
    public class UsersController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

        // GET: Users
        public ActionResult Index()
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			return View(db.Users.ToList());
        }

		public JsonResult Authenticate(string username, string password)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			bool success;
			string message;

			foreach (User u in db.Users)
			{
				if (username == u.userName)
				{
					if (password == u.password)
					{
						var result = new { success = true };
						return Json(result, JsonRequestBehavior.AllowGet);
					}

					else
					{
						var result = new { success = false, message = "Username or password is incorrect" };
						return Json(result, JsonRequestBehavior.AllowGet);
					}
				}
			}

			var resultF = new { success = false, message = "Username or password is incorrect" };
			return Json(resultF, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetByUsername(string username)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			foreach(User u in db.Users)
			{
				if(username == u.userName)
				{
					var result = new { username = u.userName, password = u.password, role = u.role };
					return Json(result, JsonRequestBehavior.AllowGet);
				}
			}

			return Json(null, JsonRequestBehavior.AllowGet);
		}

		// GET: Users/Details/5
		public ActionResult Details(string id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userName,password,role")] User user)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userName,password,role")] User user)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			User user = db.Users.Find(id);
            db.Users.Remove(user);
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
