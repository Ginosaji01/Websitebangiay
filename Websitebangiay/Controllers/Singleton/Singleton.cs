using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websitebangiay.Models;

namespace Websitebangiay.Models
{
	public class Singleton
	{
		//to have only one instance
		private static Singleton instance = new Singleton();

		static Singleton()
		{

		}

		//private constructor so can't create object
		private Singleton()
		{
		}

		public CSDLBangiay getDatabase()
		{
			CSDLBangiay db = new CSDLBangiay();
			return db;
		}

		public static Singleton Instance()
		{
			return instance;
		}
	}
}