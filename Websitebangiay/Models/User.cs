using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Websitebangiay.Models
{
	public class User
	{
		[Key]
		[StringLength(100)]
		public string userName { get; set; }

		[StringLength(100)]
		[Required]
		public string password { get; set; }

		[StringLength(100)]
		[Required]
		public string role { get; set; }
	}
}