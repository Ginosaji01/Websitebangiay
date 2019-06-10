namespace Websitebangiay.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web.Script.Serialization;

	public partial class Bill
    {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Bill()
		{
			Bill_Details = new HashSet<Bill_Detail>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int? id_customer { get; set; }

		[Column(TypeName = "date")]
		public DateTime date_order { get; set; }

		public double? total { get; set; }

		[StringLength(500)]
		public string note { get; set; }

		[StringLength(200)]
		public string status { get; set; }

		public bool isDelete { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[ScriptIgnore(ApplyToOverrides = true)]
		public virtual ICollection<Bill_Detail> Bill_Details { get; set; }

		[ScriptIgnore(ApplyToOverrides = true)]
		public virtual Customer Customers { get; set; }
	}
}
