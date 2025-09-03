// Domain/Orders/OrderDetail.cs
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.Products;

namespace ArabianCo.Domain.Orders
{
	public class OrderDetail : FullAuditedEntity   // PK = int (from base)
	{
		public int OrderId { get; set; }           // <-- int (match Order.Id)
		public virtual Order Order { get; set; } = default!;

		public int ProductId { get; set; }         // <-- int (match Product.Id)
		public virtual Product Product { get; set; } = default!;

		public int Quantity { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal UnitPrice { get; set; }

		[NotMapped]
		public decimal LineTotal => UnitPrice * Quantity;
	}
}
