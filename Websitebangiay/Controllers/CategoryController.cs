using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers.ProductRender
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AdidasProduct()
		{
			return View();
		}
    }
}