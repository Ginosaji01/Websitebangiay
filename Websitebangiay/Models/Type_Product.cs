namespace Websitebangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type_Product
    {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Type_Product()
		{
			Products = new HashSet<Product>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[StringLength(100)]
		public string name { get; set; }

		public string description { get; set; }

		public string image { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Product> Products { get; set; }
	}
}
