using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class ManageController : Controller
    {
		ProfitCalculate profit = new ProfitCalculate();
		// GET: Manage
		public ActionResult UserManage()
        {
            return View();
        }

		public ActionResult AdminManage()
		{
			return View();
		} 
		
		// Facade design pattern
		public void MonthlyProfitCalculate(int month)
		{	
			profit.Monthly_Profit_Calculate(month);
		}

		// Facade design patterns
		public void AnnualProfitCalculate(int year)
		{
			profit.Annual_Profit_Calculate(year);
		}
    }
}