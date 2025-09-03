using Abp.Application.Services.Dto;
using ArabianCo.Domain.Orders;

namespace ArabianCo.Orders.Dto;

public class PagedOrderResultRequestDto : PagedResultRequestDto
{
    public long? UserId { get; set; }
    public OrderStatus? Status { get; set; }
}
