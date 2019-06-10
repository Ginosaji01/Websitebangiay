using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class LoginController : Controller
    {
		//CSDLBangiay db = new CSDLBangiay();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

		public JsonResult UserLogin(User u)
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			var userList = db.Users.ToList();
			foreach(User user in db.Users)
			{
				if(user.userName == u.userName && user.password == u.password)
				{
					return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
				}
			}
			return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		public ActionResult Manage()
		{
			return View();
		}
    }
}