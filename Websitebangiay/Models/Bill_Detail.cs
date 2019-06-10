namespace Websitebangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Detail
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public double? quantity { get; set; }

		public double? price { get; set; }

		public int? id_type { get; set; }

		public int? id_bill { get; set; }

		public int? id_product { get; set; }

		public int size { get; set; }

		public bool isDelete { get; set; }

		public virtual Bill Bills { get; set; }

		public virtual Product Products { get; set; }
	}
}
