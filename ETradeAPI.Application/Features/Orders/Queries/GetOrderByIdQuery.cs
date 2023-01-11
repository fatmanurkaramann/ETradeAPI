using AutoMapper;
using ETradeAPI.Application.Features.Categories.Queries;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Application.RepositoryInterfaces;
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
    public class GetOrderByIdQuery : IRequest<IDataResult<ViewOrderModel>>
    {
        public string Id { get; set; }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, IDataResult<ViewOrderModel>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            public GetOrderByIdQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _orderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ViewOrderModel>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
                {
                Order? order = await _orderRepository.GetByIdAsync(request.Id,
                    include: m => m.Include(c=>c.OrderDetails).ThenInclude(c=>c.Product));
                ViewOrderModel viewModel = _mapper.Map<ViewOrderModel>(order);
                if (order == null)
                {
                    return new ErrorDataResult<ViewOrderModel>(Messages.OrderIsNotFound);
                }
                return new SuccessDataResult<ViewOrderModel>(viewModel, Messages.OrderDetailsBrought);
            }
        }
    }
}
