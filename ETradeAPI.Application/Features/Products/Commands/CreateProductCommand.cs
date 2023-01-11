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
    public class CreateProductCommand : IRequest<IDataResult<Product>>
    {
        public CreateProductModel CreateProductModel { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IDataResult<Product>>
        {
            private readonly IProductRepository _productRepository;
            private readonly ProductBusinessRules _productBusinessRules;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private IMapper _mapper;
            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, CategoryBusinessRules categoryBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _productBusinessRules.ProductNameCannotDuplicateWhenInserted(request.CreateProductModel.Name),
                    await _categoryBusinessRules.CategoryIsExist(request.CreateProductModel.CategoryId.ToString())
                    );
                if (result != null)
                {
                    return new ErrorDataResult<Product>(result.Message);
                }
                Product product = _mapper.Map<Product>(request.CreateProductModel);
                Product? createdProduct = await _productRepository.AddAsync(product);
                if (createdProduct == null)
                {
                    return new ErrorDataResult<Product>(Messages.CreateProductError);
                }
                return new SuccessDataResult<Product>(createdProduct, Messages.ProductCreated);
            }
        }
    }
}
