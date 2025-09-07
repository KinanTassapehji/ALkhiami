namespace ArabianCo.Orders.Dto;

public class CreateOrderDetailDto
{
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal UnitPrice { get; set; }
}
