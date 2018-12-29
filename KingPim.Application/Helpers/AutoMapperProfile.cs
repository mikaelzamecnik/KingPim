using AutoMapper;
using KingPim.Application.Account;
using KingPim.Domain.Entities;
using KingPim.Application.Repositories.Models;

namespace KingPim.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<SubCategory, SubCategoryModel>().ReverseMap();
            CreateMap<ProductAttribute, ProductAttributeModel>().ReverseMap();
            CreateMap<AttributeOptionList, AttributeOptionListModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<AttributeGroup, AttributeGroupModel>().ReverseMap();
            CreateMap<ProductAttributeValue, ProductAttributeValuesModel>().ReverseMap();

        }
    }
}
