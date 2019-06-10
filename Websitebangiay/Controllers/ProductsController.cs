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
	public class ProductsController : Controller
	{
		//private CSDLBangiay db = new CSDLBangiay();

		// GET: Products
		public ActionResult Index()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			List<Product> products = new List<Product>();
			foreach (Product p in db.Products)
			{
				if (p.isDelete == false)
				{
					products.Add(p);
				}
			}

			return View(products);
		}

		// GET: Products/Details/5
		public ActionResult Details(int? id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// GET: Products/Create
		public ActionResult Create()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			ViewBag.id_type = new SelectList(db.Type_Products, "Id", "name");
			return View();
		}

		// POST: Products/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,title,image,image1,image2,image3,image4,description,price,category,stock,rating,id_type,moi,isDelete")] Product product)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.id_type = new SelectList(db.Type_Products, "Id", "name", product.id_type);
			return View(product);
		}

		// GET: Products/Edit/5
		public ActionResult Edit(int? id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			ViewBag.id_type = new SelectList(db.Type_Products, "Id", "name", product.id_type);
			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,title,image,image1,image2,image3,image4,description,price,category,stock,rating,id_type,moi,isDelete")] Product product)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (ModelState.IsValid)
			{
				db.Entry(product).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.id_type = new SelectList(db.Type_Products, "Id", "name", product.id_type);
			return View(product);
		}

		// GET: Products/Delete/5
		public ActionResult Delete(int? id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			Product product = db.Products.Find(id);
			product.isDelete = true;
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

		public JsonResult GetAdidasProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			db.Configuration.ProxyCreationEnabled = false;

			db.Configuration.ProxyCreationEnabled = false;
			AdidasProductsRender adidasProductList = new AdidasProductsRender();
			var result = adidasProductList.Render();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetNikeProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			db.Configuration.ProxyCreationEnabled = false;
			NikeProductsRender nikeProductList = new NikeProductsRender();
			var result = nikeProductList.Render();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetPumaProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			db.Configuration.ProxyCreationEnabled = false;

			PumaProductsRender pumaProductList = new PumaProductsRender();
			var result = pumaProductList.Render();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetConverseProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			db.Configuration.ProxyCreationEnabled = false;

			ConverseProductsRender converseProductList = new ConverseProductsRender();
			var result = converseProductList.Render();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetAllProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			db.Configuration.ProxyCreationEnabled = false;

			var result = db.Products.ToList();
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}