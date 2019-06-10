namespace Websitebangiay.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CSDLBangiay : DbContext
    {
        public CSDLBangiay()
            : base("name=CSDLBangiay")
        {
        }

		public virtual DbSet<Bill_Detail> Bill_Details { get; set; }
		public virtual DbSet<Bill> Bills { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Type_Product> Type_Products { get; set; }
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bill>()
				.Property(e => e.note)
				.IsUnicode(false);

			modelBuilder.Entity<Bill>()
				.HasMany(e => e.Bill_Details)
				.WithOptional(e => e.Bills)
				.HasForeignKey(e => e.id_bill);

			modelBuilder.Entity<Customer>()
				.Property(e => e.address)
				.IsUnicode(false);

			modelBuilder.Entity<Customer>()
				.Property(e => e.phone)
				.IsUnicode(false);

			modelBuilder.Entity<Customer>()
				.Property(e => e.note)
				.IsUnicode(false);

			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Bills)
				.WithOptional(e => e.Customers)
				.HasForeignKey(e => e.id_customer);

			modelBuilder.Entity<News>()
				.Property(e => e.title)
				.IsUnicode(false);

			modelBuilder.Entity<News>()
				.Property(e => e.content)
				.IsUnicode(false);

			modelBuilder.Entity<News>()
				.Property(e => e.image)
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Bill_Details)
				.WithOptional(e => e.Products)
				.HasForeignKey(e => e.id_product);

			modelBuilder.Entity<Type_Product>()
				.HasMany(e => e.Products)
				.WithOptional(e => e.Type_Products)
				.HasForeignKey(e => e.id_type);
		}
	}
}
