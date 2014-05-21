using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using EF5Repository.Data.Models;
using EF5Repository.Service.DataObjects;

namespace EF5Repository.Service.Profiles
{
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Customer, CustomerDataObject>();
            CreateMap<CustomerDataObject, Customer>();
        }
    }
}
