using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websitebangiay.Models;

namespace Websitebangiay.Models
{
	public abstract class RenderProducts
	{
		public virtual List<Product> GetAllProduct()
		{
			var singleton = Singleton.Instance();
			var db = singleton.getDatabase();
			return db.Products.ToList();
		}

		public abstract List<Product> SortProductByCategory(List<Product> listAllProduct);

		//Template Method Pattern
		public List<Product> Render()
		{
			List<Product> allProduct = GetAllProduct();
			var productList = SortProductByCategory(allProduct);
			return productList;
		}
	}
}