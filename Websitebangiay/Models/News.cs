namespace Websitebangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class News
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[StringLength(50)]
		public string title { get; set; }

		[Column(TypeName = "text")]
		public string content { get; set; }

		public string image { get; set; }
	}
}
