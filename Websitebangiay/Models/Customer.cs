namespace Websitebangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class Customer
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Customer()
		{
			Bills = new HashSet<Bill>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[StringLength(100)]
		public string fullName { get; set; }

		[StringLength(50)]
		public string address { get; set; }

		public string email { get; set; }

		[StringLength(50)]
		public string phone { get; set; }

		[StringLength(200)]
		public string note { get; set; }

		public bool isDelete { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Bill> Bills { get; set; }
	}
}
