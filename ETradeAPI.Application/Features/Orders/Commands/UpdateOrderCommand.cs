using AutoMapper;
using ETradeAPI.Application.Features.Categories.Models;
using ETradeAPI.Application.Features.Categories.Rules;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Application.Features.Orders.Rules;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.BusinessRules;
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
    public class UpdateOrderCommand : IRequest<IDataResult<Order>>
    {
        public UpdateOrderModel UpdateOrderModel { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IDataResult<Order>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly OrderBusinessRules _orderBusinessRules;

            public UpdateOrderCommandHandler(IOrderRepository OrderRepository , IMapper mapper, OrderBusinessRules orderBusinessRules)
            {
                _orderRepository = OrderRepository;
                _mapper = mapper;
                _orderBusinessRules = orderBusinessRules;
            }
            public async Task<IDataResult<Order>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _orderBusinessRules.CheckIfOrderIsExist(request.UpdateOrderModel.Id)
                    );
                if (result != null)
                {
                    return new ErrorDataResult<Order>(result.Message);
                }
                Order order = _mapper.Map<Order>(request.UpdateOrderModel);
                Order updatedOrder = await _orderRepository.UpdateAsync(order);
                return new SuccessDataResult<Order>(updatedOrder, Messages.OrderUpdated);
            }
        }
    }
}
