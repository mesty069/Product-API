using AutoMapper;
using Product.API.MyHelper;
using Product.Core.Dto;
using Product.Core.Entities.Order;

namespace Product.API.Models
{
    public class MappingOrders : Profile
    {
        public MappingOrders() 
        {
            CreateMap<ShipAddress, AddressDto>().ReverseMap();
            CreateMap<Order, OrderToretunrnDto>()
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(x => x.DeliveryMethod.Price))
                .ReverseMap();
            CreateMap<OrderItems, OrderItemDto>()
                .ForMember(d => d.ProductItemId, o => o.MapFrom(s => s.OrderItemsId))
                .ForMember(d => d.ProductItemName, o => o.MapFrom(s => s.productItemOrderd.ProductItemName))
                .ForMember(d => d.PrictureUrl, o => o.MapFrom(s => s.productItemOrderd.PrictureUrl))
                .ForMember(d => d.PrictureUrl, o => o.MapFrom<OrderItemUrlResolver>()).ReverseMap();
        }
    }
}
