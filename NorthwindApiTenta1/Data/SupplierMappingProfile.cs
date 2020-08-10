using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthwindApiTenta1.Data.Entities;
using NorthwindApiTenta1.Models;

namespace NorthwindApiTenta1.Data
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Suppliers, SupplierModel>().ReverseMap();
            CreateMap<Products, ProductModel>();
        }
    }
}