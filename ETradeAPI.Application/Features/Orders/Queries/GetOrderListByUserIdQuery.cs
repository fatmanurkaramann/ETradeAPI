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
    public class GetOrderListByUserIdQuery : IRequest<IDataResult<OrderListModel>>
    {
        public Guid UserId { get; set; }
        public RequestParameter RequestParameter { get; set; }
        public class GetOrderListByUserIdQueryHandler : IRequestHandler<GetOrderListByUserIdQuery, IDataResult<OrderListModel>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetOrderListByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<OrderListModel>> Handle(GetOrderListByUserIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> orders = await _orderRepository.GetListAsync(
                    predicate: o=> o.UserId == request.UserId,
                    orderBy: m=> m.OrderBy(o=>o.CreatedDate),
                    index: request.RequestParameter.Page, 
                    size: request.RequestParameter.PageSize,
                    include: m => m.Include(c => c.OrderDetails).ThenInclude(c => c.Product).ThenInclude(p=>p.Category));
                OrderListModel orderListModel = _mapper.Map<OrderListModel>(orders);
                return new SuccessDataResult<OrderListModel>(orderListModel, Messages.OrdersListed);
            }
        }
    }
}
