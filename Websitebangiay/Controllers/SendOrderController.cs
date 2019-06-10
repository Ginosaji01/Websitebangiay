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
    public class SendOrderController : Controller
    {
		public class ItemInCartData
		{
			public int Id { get; set; }

			public string image { get; set; }

			public int? id_type { get; set; }

			public string title { get; set; }

			public double? price { get; set; }

			public double? quantity { get; set; }

			public int size { get; set; }
		}


		//private CSDLBangiay db = new CSDLBangiay();

		// GET: SendData
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult CreateCustomerData(Customer customerInfo, int total)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			//Create customer
			var lastCus = db.Customers.OrderByDescending(c => c.Id).FirstOrDefault();
			if (lastCus == null)
			{
				customerInfo.Id = 1;
			}
			else
			{
				customerInfo.Id = lastCus.Id + 1;
			}

			
			
			//Create customer's bill
			var bill = new Bill();
			var lastBil = db.Bills.OrderByDescending(b => b.Id).FirstOrDefault();
			if(lastBil == null)
			{
				bill.Id = 1;
			}

			else
			{
				bill.Id = lastBil.Id + 1;
			}

			bill.id_customer = customerInfo.Id;
			bill.date_order = DateTime.Now; //get date and time when create this bill
			bill.total = total;
			bill.note = customerInfo.note;
			bill.status = "In queue";
			bill.isDelete = false;

			db.Customers.Add(customerInfo); // Add customer data to database
			db.Bills.Add(bill); // Add customer's bill to database
			db.SaveChanges();
			return Json(bill.Id, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public void CreateBillDetail(List<ItemInCartData> customerCart, int bill_Id)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			foreach (ItemInCartData item in customerCart)
			{
				Bill_Detail billDetail = new Bill_Detail();
				var lastBillDetail = db.Bill_Details.OrderByDescending(c => c.Id).FirstOrDefault();
				if (lastBillDetail == null)
				{
					billDetail.Id = 1;
				}
				else
				{
					billDetail.Id = lastBillDetail.Id + 1;
				}

				billDetail.id_product = item.Id;
				billDetail.id_bill = bill_Id;
				billDetail.quantity = item.quantity;
				billDetail.price = item.price;
				billDetail.size = item.size;
				billDetail.id_type = item.id_type;
				db.Bill_Details.Add(billDetail);
				db.SaveChanges();
			}			
		}
	}
}