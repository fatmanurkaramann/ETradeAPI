using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Rules
{
    public class OrderBusinessRules
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBusinessRules(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IResult> CheckIfOrderIsExist(string id)
        {
            Order? order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return new ErrorResult(Messages.OrderIsNotFound);

            }
            return new SuccessResult();
        }
        public IResult CheckOrderStatus(OrderStatus orderStatus)
        {
            if (OrderStatus.OnWay == orderStatus)
            {
                return new ErrorResult(Messages.OrderIsOnWayCannotUpdate);
            }
            return new SuccessResult();
        }
    }
}
