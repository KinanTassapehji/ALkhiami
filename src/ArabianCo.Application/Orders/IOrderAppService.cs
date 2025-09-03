using ArabianCo.CrudAppServiceBase;
using ArabianCo.Orders.Dto;

namespace ArabianCo.Orders;

public interface IOrderAppService : IArabianCoAsyncCrudAppService<OrderDto, int, LiteOrderDto, PagedOrderResultRequestDto, CreateOrderDto, UpdateOrderDto>
{
}
