using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Authorization.Users;

namespace ArabianCo.Domain.Orders
{
	public class Order : FullAuditedEntity  // PK: long (from base)
	{
		[Required]
		public long UserId { get; set; }              // matches User.Id (long)

		public virtual User User { get; set; }        // no [ForeignKey] attribute

		public OrderStatus Status { get; set; } = OrderStatus.Pending;

		[Column(TypeName = "decimal(18,2)")]
		public decimal Subtotal { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Discount { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Tax { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Shipping { get; set; }

		[NotMapped]
		public decimal Total => Subtotal - Discount + Tax + Shipping;

		public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
	}
}
