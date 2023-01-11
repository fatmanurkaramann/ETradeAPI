using AutoMapper;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Commands
{
    public class CreateOrderCommand:IRequest<IDataResult<Order>>
    {
        public CreateOrderModel CreateOrderModel{ get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IDataResult<Order>>
        {
            private readonly IMapper _mapper;
            private readonly IOrderRepository _orderRepository;

            public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
            }
            public async Task<IDataResult<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = _mapper.Map<Order>(request.CreateOrderModel);
                try
                {
                    Order createdOrder = await _orderRepository.AddAsync(order);

                }
                catch (Exception e )
                {

                    throw;
                }
                return new SuccessDataResult<Order>(order, Messages.OrderCreated);
            }
        }
    }
}
