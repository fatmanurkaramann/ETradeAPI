using AutoMapper;
using ETradeAPI.Application.Features.Categories.Models;
using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryModel>().ReverseMap();
            CreateMap<CategoryListModel, IPaginate<Category>>().ReverseMap();
        }
    }
}
