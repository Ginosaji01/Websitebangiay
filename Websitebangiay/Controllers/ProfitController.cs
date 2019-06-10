using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class ProfitController : Controller
    {
		//CSDLBangiay db = new CSDLBangiay();
		ProfitCalculate p = new ProfitCalculate();
		// GET: Profit
		public ActionResult Profit()
        {
            return View();
        }

		public JsonResult GetBillByMonth(int month)
		{
			var result = p.GetBillByMonth(month);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetBillByYear(int year)
		{
			var result = p.GetBillByYear(year);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public double? MonthlyProfitCalculate(int month)
		{
			return p.Monthly_Profit_Calculate(month);
		}

		public double? YearlyProfitCalculate(int year)
		{
			return p.Annual_Profit_Calculate(year);
		}
    }
}