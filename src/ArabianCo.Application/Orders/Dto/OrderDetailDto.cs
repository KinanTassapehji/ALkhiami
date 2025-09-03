using Abp.Application.Services.Dto;

namespace ArabianCo.Orders.Dto;

public class OrderDetailDto : EntityDto<int>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}
