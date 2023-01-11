using AutoMapper;
using ETradeAPI.Application.Features.Products.Models;
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

namespace ETradeAPI.Application.Features.Categories.Queries
{
    public class GetProductByIdQuery : IRequest<IDataResult<ViewProductModel>>
    {
        public string Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IDataResult<ViewProductModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetProductByIdQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _productRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ViewProductModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetByIdAsync(request.Id,include:m=>m.Include(c=>c.Category));
                ViewProductModel viewModel = _mapper.Map<ViewProductModel>(product);
                if (product == null)
                {
                    return new ErrorDataResult<ViewProductModel>(Messages.ProductNotFound);
                }
                return new SuccessDataResult<ViewProductModel>(viewModel, Messages.ProductDetailsBrought);
            }
        }
    }
}
