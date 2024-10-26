using AutoMapper;
using Product.Core.Dto;
using Product.Core.Entities.Order;

namespace Product.API.MyHelper
{
    public class OrderItemUrlResolver : IValueResolver<OrderItems, OrderItemDto, string>
    {
        private readonly IConfiguration _config;
        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// 圖片URL解析器
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Resolve(OrderItems source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.productItemOrderd.PrictureUrl))
            {
                return _config["ApiURL"] + source.productItemOrderd.PrictureUrl;
            }
            return null;
        }
    }
}
