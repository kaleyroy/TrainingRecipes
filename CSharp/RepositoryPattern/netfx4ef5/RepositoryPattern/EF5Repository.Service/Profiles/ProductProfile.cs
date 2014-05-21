using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using EF5Repository.Data.Models;
using EF5Repository.Service.DataObjects;

namespace EF5Repository.Service.Profiles
{
    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Category, CategoryDataObject>()
                .ForMember(dest => dest.Products,opt => opt.Ignore());
            CreateMap<CategoryDataObject, CategoryDataObject>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<Product, ProductDataObject>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<ProductDataObject, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
