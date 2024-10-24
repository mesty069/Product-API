using AutoMapper;
using Product.API.MyHelper;
using Product.Core.Entities;
using Product.Infrastructure.Data;

namespace Product.API.Models
{
    public class Mapping_Products : Profile
    {
        public Mapping_Products()
        {
            CreateMap<Products, ProductDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category))
                .ForMember(d => d.ProductPicture, o => o.MapFrom<ProductUrlResolver>())
                .ReverseMap();
            CreateMap<CreateProductDto, Products>().ReverseMap();
        }
    }
}
