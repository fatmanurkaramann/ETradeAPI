using AutoMapper;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductModel>().ReverseMap();
            CreateMap<Product, UpdateProductModel>().ReverseMap();
            CreateMap<Product,ViewProductModel>().ReverseMap();
            CreateMap<ProductListModel, IPaginate<Product>>().ReverseMap();
            CreateMap<ProductListModel, IPaginate<Product>>().ReverseMap();

        }
    }
}
