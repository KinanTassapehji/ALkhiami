using ArabianCo.Domain.Orders;
using ArabianCo.Orders.Dto;
using AutoMapper;

namespace ArabianCo.Orders.Mapper;

internal class OrderMapProfile : Profile
{
    public OrderMapProfile()
    {
        CreateMap<CreateOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();
        CreateMap<CreateOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
    }
}
