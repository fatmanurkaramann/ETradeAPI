using AutoMapper;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Requests;
using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Queries
{
    public class GetOrderListQuery : IRequest<IDataResult<OrderListModel>>
    {
        public RequestParameter RequestParameter { get; set; }
        public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IDataResult<OrderListModel>>
        {
            private IOrderRepository _orderRepository;
            private IMapper _mapper;

            public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<OrderListModel>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> orders = await _orderRepository.GetListAsync(
                    index: request.RequestParameter.Page,size: request.RequestParameter.PageSize,
                    include: m => m.Include(c => c.OrderDetails).ThenInclude(c => c.Product).ThenInclude(p=>p.Category));
                OrderListModel orderListModel = _mapper.Map<OrderListModel>(orders);
                return new SuccessDataResult<OrderListModel>(orderListModel,Messages.OrdersListed);
            }
        }
    }
}
