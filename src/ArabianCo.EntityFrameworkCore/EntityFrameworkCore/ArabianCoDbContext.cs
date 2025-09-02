// File: EntityFrameworkCore/ArabianCoDbContext.cs
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ArabianCo.Authorization.Roles;
using ArabianCo.Authorization.Users;
using ArabianCo.MultiTenancy;

// Domain namespaces
using ArabianCo.Domain.Countries;
using ArabianCo.Domain.Cities;
using ArabianCo.Domain.Addresses;
using ArabianCo.Domain.Attachments;
using ArabianCo.Domain.Categories;
using ArabianCo.Domain.Brands;
using ArabianCo.Domain.FrequentlyQuestions;
using ArabianCo.Domain.Attributes;
using ArabianCo.Domain.AttributeValues;
using ArabianCo.Domain.Products;
using ArabianCo.Domain.Orders;
using ArabianCo.Domain.MaintenanceRequests;
using ArabianCo.Domain.ACInstalls;
using ArabianCo.Domain.Questions;
using ArabianCo.Domain.AboutUss;
using ArabianCo.Domain.OurProjects;

namespace ArabianCo.EntityFrameworkCore
{
	public class ArabianCoDbContext
		: AbpZeroDbContext<Tenant, Role, User, ArabianCoDbContext>
	{
		public ArabianCoDbContext(DbContextOptions<ArabianCoDbContext> options)
			: base(options)
		{
		}

		// ---- DbSets ----
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<CountryTranslation> CountryTranslations { get; set; }
		public virtual DbSet<City> Cities { get; set; }
		public virtual DbSet<CityTranslation> CityTranslations { get; set; }
		public virtual DbSet<Address> Addresses { get; set; }
		public virtual DbSet<Attachment> Attachments { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<CategoryTranslation> CategoryTranslations { get; set; }
		public virtual DbSet<Brand> Brands { get; set; }
		public virtual DbSet<BrandTranslation> BrandTranslations { get; set; }
		public virtual DbSet<FrequentlyQuestion> FrequentlyQuestions { get; set; }
		public virtual DbSet<FrequentlyQuestionTranslation> FrequentlyQuestionTranslations { get; set; }
		public virtual DbSet<Domain.Attributes.Attribute> Attributes { get; set; }  // avoid clash with System.Attribute
		public virtual DbSet<AttributeTranslation> AttributeTranslations { get; set; }
		public virtual DbSet<AttributeValue> AttributeValues { get; set; }
		public virtual DbSet<AttributeValueTranslation> AttributeValueTranslations { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<ProductTranslation> ProductTranslations { get; set; }
		public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
		public virtual DbSet<ACInstall> ACInstalls { get; set; }
		public virtual DbSet<Question> Questions { get; set; }
		public virtual DbSet<AboutUs> AboutUss { get; set; }
		public virtual DbSet<AboutUsTranslation> AboutUsTranslations { get; set; }
		public virtual DbSet<OurProject> OurProjects { get; set; }
		public virtual DbSet<OurProjectsTranslation> OurProjectsTranslations { get; set; }

		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// ---- Table names (be explicit so runtime == migrations) ----
			modelBuilder.Entity<Order>().ToTable("Orders");
			modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
			modelBuilder.Entity<Product>().ToTable("Products");

			// ---- Decimal precision ----
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Order>()
				.Property(o => o.Subtotal)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Order>()
				.Property(o => o.Discount)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Order>()
				.Property(o => o.Tax)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Order>()
				.Property(o => o.Shipping)
				.HasPrecision(18, 2);

			modelBuilder.Entity<OrderDetail>()
				.Property(od => od.UnitPrice)
				.HasPrecision(18, 2);

			// ---- Relationships (define ONCE, no duplicates) ----

			// Order -> User (many orders per user)
			modelBuilder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			// OrderDetail -> Order (many details per order)
			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			// OrderDetail -> Product (many details per product)
			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			// AttributeValue -> Product (single consistent mapping)
			modelBuilder.Entity<AttributeValue>()
				.HasOne(av => av.Product)
				.WithMany(p => p.AttributeValues)
				.HasForeignKey(av => av.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

			// ---- Indexes / Uniqueness ----

			// Unique ModelNumber when provided
			modelBuilder.Entity<Product>()
				.HasIndex(p => p.ModelNumber)
				.IsUnique()
				.HasFilter("[ModelNumber] IS NOT NULL");

			// Prevent duplicate product lines in the same order
			modelBuilder.Entity<OrderDetail>()
				.HasIndex(od => new { od.OrderId, od.ProductId })
				.IsUnique();
		}
	}
}
