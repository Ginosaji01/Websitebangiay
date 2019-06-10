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
    public class NewsController : Controller
    {
        //private CSDLBangiay db = new CSDLBangiay();

        // GET: News
        public ActionResult Index()
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			return View(db.News.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,content,image")] News news)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,content,image")] News news)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			News news = db.News.Find(id);
            db.News.Remove(news);
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
