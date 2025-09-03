using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.AttributeValues;
using ArabianCo.Domain.Brands;
using ArabianCo.Domain.Categories;
using ArabianCo.Domain.Orders;

namespace ArabianCo.Domain.Products
{
	public class Product : FullAuditedEntity, IMultiLingualEntity<ProductTranslation>
	{
		public Product()
		{
			AttributeValues = new HashSet<AttributeValue>();
			Translations = new HashSet<ProductTranslation>();
			OrderDetails = new HashSet<OrderDetail>();
		}

		public string ModelNumber { get; set; }
		public int StockQuantity { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public int BrandId { get; set; }
		public virtual Brand Brand { get; set; }

		public bool IsActive { get; set; }
		[DefaultValue(false)]
		public bool IsSpecial { get; set; }

		public virtual ICollection<AttributeValue> AttributeValues { get; set; }
		public virtual ICollection<ProductTranslation> Translations { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
