using AutoMapper;
using ETradeAPI.Application.Features.OrderDetails.Models;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderModel, Order>().ReverseMap();
            CreateMap<CreateOrderDetailModel, OrderDetail>().ReverseMap();
            CreateMap<ViewOrderModel, Order>().ReverseMap();
            CreateMap<ViewOrderDetailModel, OrderDetail>().ReverseMap();
            CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap();
        }
    }
}
