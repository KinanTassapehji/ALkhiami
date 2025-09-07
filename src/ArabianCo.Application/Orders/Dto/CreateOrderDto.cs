using System.Collections.Generic;

namespace ArabianCo.Orders.Dto;

public class CreateOrderDto
{
	public long UserId { get; set; }
	public decimal Discount { get; set; }
	public decimal Tax { get; set; }
	public decimal Shipping { get; set; }
	public List<CreateOrderDetailDto> OrderDetails { get; set; }
}
