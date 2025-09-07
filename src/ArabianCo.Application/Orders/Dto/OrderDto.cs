using Abp.Application.Services.Dto;
using ArabianCo.Domain.Orders;
using System.Collections.Generic;

namespace ArabianCo.Orders.Dto;

public class OrderDto : EntityDto<int>
{
	public long UserId { get; set; }
	public OrderStatus Status { get; set; }
	public decimal Subtotal { get; set; }
	public decimal Discount { get; set; }
	public decimal Tax { get; set; }
	public decimal Shipping { get; set; }
	public decimal Total { get; set; }
	public List<OrderDetailDto> OrderDetails { get; set; }
}
