using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Websitebangiay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Contact()
		{
			return View();
		}

		public ActionResult GioiThieuSPPartial()
		{
			return View();
		}

		public ActionResult SanPhamDetail()
		{
			return View();
		}

		public ActionResult RenderProduct()
		{
			return View();
		}

		public ActionResult All_Product_List()
		{
			return View();
		}

		public ActionResult All_Product_Item()
		{
			return View();
		}

		public ActionResult All_Adidas_Product_Item()
		{
			return View();
		}

		public ActionResult All_Adidas_Product_List()
		{
			return View();
		}

		public ActionResult All_Nike_Product_Item()
		{
			return View();
		}

		public ActionResult All_Nike_Product_List()
		{
			return View();
		}

		public ActionResult All_Converse_Product_Item()
		{
			return View();
		}

		public ActionResult All_Converse_Product_List()
		{
			return View();
		}

		public ActionResult All_Puma_Product_List()
		{
			return View();
		}

		public ActionResult All_Puma_Product_Item()
		{
			return View();
		}
	}
}