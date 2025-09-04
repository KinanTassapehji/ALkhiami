using ArabianCo.CrudAppServiceBase;
using ArabianCo.Orders.Dto;

namespace ArabianCo.Orders;

internal interface IOrderAppService : IArabianCoAsyncCrudAppService<OrderDto, int, LiteOrderDto, PagedOrderResultRequestDto, CreateOrderDto, UpdateOrderDto>
{
}
