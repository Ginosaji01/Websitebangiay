using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websitebangiay.Models;

namespace Websitebangiay.Models
{
	public class NikeProductsRender : RenderProducts
	{
		public override List<Product> SortProductByCategory(List<Product> listAllProduct)
		{
			List<Product> listProductAfterSort = new List<Product>();

			foreach (Product p in listAllProduct)
			{
				if (p.id_type == 2)
				{
					listProductAfterSort.Add(p);
				}
			}

			return listProductAfterSort;
		}
	}
}