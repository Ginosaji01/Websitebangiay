namespace Websitebangiay.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web.Script.Serialization;

	public partial class Product
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Product()
		{
			Bill_Details = new HashSet<Bill_Detail>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[StringLength(100)]
		public string title { get; set; }

		public string image { get; set; }

		public string image1 { get; set; }

		public string image2 { get; set; }

		public string image3 { get; set; }

		public string image4 { get; set; }

		public string description { get; set; }

		public double? price { get; set; }

		[StringLength(50)]
		public string category { get; set; }

		public int? stock { get; set; }

		public int? rating { get; set; }

		public int? id_type { get; set; }

		public int? moi { get; set; }

		public bool isDelete { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[ScriptIgnore(ApplyToOverrides = true)]
		public virtual ICollection<Bill_Detail> Bill_Details { get; set; }

		[ScriptIgnore(ApplyToOverrides = true)]
		public virtual Type_Product Type_Products { get; set; }
	}
}
