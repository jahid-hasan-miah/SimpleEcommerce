using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = ECommerceSystem.ProductManaging.Entities;
using BO = ECommerceSystem.ProductManaging.BusinessObjects;

namespace ECommerceSystem.ProductManaging.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<EO.Product, BO.Product>().ReverseMap();
        }
    }
}
