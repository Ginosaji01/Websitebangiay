using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websitebangiay.Models;

namespace Websitebangiay.Models
{
	public class ProfitCalculate
	{
		//singleton
		//CSDLBangiay db = new CSDLBangiay(); <= create n instance if write this line n time

		public List<Bill> GetBillByMonth(int month)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();

			List<Bill> billList = new List<Bill>();
			foreach(Bill b in db.Bills)
			{
				//get bill by month
				if(b.date_order.Month == month)
				{
					billList.Add(b);
				}		
			}

			return billList;
		}

		public List<Bill> GetBillByYear(int year)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			List<Bill> billList = new List<Bill>();
			foreach(Bill b in db.Bills)
			{
				//get bill by year
				if(b.date_order.Year == year)
				{
					billList.Add(b);
				}
			}
			return billList;
		}

		public double? CheckNullList(List<Bill> billList)
		{
			double? profit = 0;
			if(billList.Count == 0)
			{
				//if list of bill is null then return 0;
				return profit;
			}

			else
			{
				//if list of bill is not null then return profit calculate function
				return Profit_Calculate(billList); ;
			}
		}

		public double? Profit_Calculate(List<Bill> billList)
		{
			double? profit = 0;
			foreach (Bill b in billList)
			{
				profit += b.total;
			}
			return profit;
		}

		public double? Monthly_Profit_Calculate(int month)
		{
			return CheckNullList(GetBillByMonth(month));
		}

		public double? Annual_Profit_Calculate(int year)
		{
			return CheckNullList(GetBillByYear(year));
		}
	}
}