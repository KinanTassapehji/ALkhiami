using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.Orders;
using ArabianCo.Orders.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace ArabianCo.Orders;

public class OrderAppService : ArabianCoAsyncCrudAppService<Order, OrderDto, int, LiteOrderDto, PagedOrderResultRequestDto, CreateOrderDto, UpdateOrderDto>, IOrderAppService
{
    public OrderAppService(IRepository<Order, int> repository) : base(repository)
    {
    }

    public override async Task<OrderDto> CreateAsync(CreateOrderDto input)
    {
        var entity = MapToEntity(input);
		entity.Status = OrderStatus.Pending;
		if (entity.OrderDetails != null)
        {
            entity.Subtotal = entity.OrderDetails.Sum(d => d.UnitPrice * d.Quantity);
        }
        await Repository.InsertAsync(entity);
        await CurrentUnitOfWork.SaveChangesAsync();
        return MapToEntityDto(entity);
    }

    public override async Task<OrderDto> UpdateAsync(UpdateOrderDto input)
    {
        var entity = await GetEntityByIdAsync(input.Id);
        entity.OrderDetails.Clear();
        MapToEntity(input, entity);
        if (entity.OrderDetails != null)
        {
            entity.Subtotal = entity.OrderDetails.Sum(d => d.UnitPrice * d.Quantity);
        }
        await CurrentUnitOfWork.SaveChangesAsync();
        return MapToEntityDto(entity);
    }
	public override async Task DeleteAsync(EntityDto<int> input)
	{
		CheckDeletePermission();

		var entity = await Repository.GetAsync(input.Id);
		entity.Status = OrderStatus.Cancelled;

		await Repository.UpdateAsync(entity);
		await Repository.DeleteAsync(entity);
		await CurrentUnitOfWork.SaveChangesAsync();
	}
	protected override IQueryable<Order> CreateFilteredQuery(PagedOrderResultRequestDto input)
    {
        var query = base.CreateFilteredQuery(input);
        if (input.UserId.HasValue)
        {
            query = query.Where(o => o.UserId == input.UserId.Value);
        }
        if (input.Status.HasValue)
        {
            query = query.Where(o => o.Status == input.Status.Value);
        }
        return query;
    }
}
