using ETradeAPI.Application.Features.Categories.Rules;
using ETradeAPI.Application.Features.Products.Rules;
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

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<IResult>
    {
        public string Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, IResult>
        {
            private readonly IProductRepository _productRepository;
            private readonly ProductBusinessRules _productBusinessRules;

            public DeleteProductByIdCommandHandler(IProductRepository productRepository, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<IResult> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(await _productBusinessRules.CheckIfProductIsExist(request.Id));
                if (result != null)
                    return new ErrorResult(result.Message);
                var deleteResult = await _productRepository.DeleteByIdAsync(request.Id);
                if (deleteResult <= 0)
                {
                    return new ErrorResult();
                }
                return new SuccessResult(Messages.ProductDeleted);

            }
        }
    }
}
