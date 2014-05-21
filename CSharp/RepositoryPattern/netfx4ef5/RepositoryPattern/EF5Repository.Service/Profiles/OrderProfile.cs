using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using EF5Repository.Data.Models;
using EF5Repository.Service.DataObjects;

namespace EF5Repository.Service.Profiles
{
    public class OrderProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Order, OrderDataObject>()
                .ForMember(dest => dest.SubTotal, opt => 
                    opt.MapFrom(o => o.OrderDetails.Sum(i => i.UnitPrice * i.Quantity)));
            CreateMap<OrderDataObject, Order>();

            CreateMap<OrderDetail, OrderDetailDataObject>()
                .ForMember(dest => dest.Order, opt => opt.Ignore());
            CreateMap<OrderDetailDataObject, OrderDetail>()
                .ForMember(dest => dest.Order,opt => opt.Ignore())
                .ForMember(dest => dest.Product,opt => opt.Ignore());
        }
    }
}
