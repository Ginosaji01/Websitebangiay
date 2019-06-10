using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Websitebangiay.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult CartDetails()
        {
            return View();
        }

		public ActionResult CheckOut()
		{
			return View();
		}

		public ActionResult OrderReceived()
		{
			return View();
		}
    }
}