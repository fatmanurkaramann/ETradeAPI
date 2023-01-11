
using ETradeAPI.Application.Features.Orders.Rules;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.BusinessRules;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Commands
{
    public class DeleteOrderByIdCommand : IRequest<IResult>
    {
        public string Id { get; set; }

        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, IResult>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly OrderBusinessRules _orderBusinessRules;

            public DeleteOrderByIdCommandHandler(IOrderRepository OrderRepository, OrderBusinessRules OrderBusinessRules)
            {
                _orderRepository = OrderRepository;
                _orderBusinessRules = OrderBusinessRules;
            }

            public async Task<IResult> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(await _orderBusinessRules.CheckIfOrderIsExist(request.Id));
                if (result != null)
                    return new ErrorResult(result.Message);
                var deleteResult = await _orderRepository.DeleteByIdAsync(request.Id);
                if (deleteResult <= 0)
                {
                    return new ErrorResult();
                }
                return new SuccessResult(Messages.OrderDeleted);

            }
        }
    }
}
