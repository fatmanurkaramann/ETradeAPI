using AutoMapper;
using ETradeAPI.Application.Features.Categories.Rules;
using ETradeAPI.Application.Features.Products.Models;
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
    public class UpdateProductCommand : IRequest<IDataResult<Product>>
    {
        public UpdateProductModel UpdateProductModel { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IDataResult<Product>>
        {
            private readonly IProductRepository _productRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly ProductBusinessRules _productBusinessRules;
            private IMapper _mapper;
            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, CategoryBusinessRules categoryBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _categoryBusinessRules.CategoryIsExist(request.UpdateProductModel.CategoryId.ToString())
                    );
                if (result != null)
                {
                    return new ErrorDataResult<Product>(result.Message);
                }
                Product product = _mapper.Map<Product>(request.UpdateProductModel);
                Product? updatedProduct = await _productRepository.UpdateAsync(product);
                if (updatedProduct == null)
                {
                    return new ErrorDataResult<Product>(Messages.UpdateProductError);
                }
                return new SuccessDataResult<Product>(updatedProduct, Messages.ProductUpdated);
            }
        }
    }
}
