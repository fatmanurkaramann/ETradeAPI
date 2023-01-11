using AutoMapper;
using ETradeAPI.Application.Features.Products.Models;
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

namespace ETradeAPI.Application.Features.Products.Queries
{
    public class GetProductListByCategoryIdQuery:IRequest<IDataResult<ProductListModel>>
    {
        public RequestParameter RequestParameter { get; set; }
        public Guid CategoryId { get; set; }

        public class GetProductListByCategoryIdQueryHandler
            : IRequestHandler<GetProductListByCategoryIdQuery, IDataResult<ProductListModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetProductListByCategoryIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ProductListModel>> Handle(GetProductListByCategoryIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(predicate: p => p.CategoryId == request.CategoryId, include: m => m.Include(c => c.Category),
                    index: request.RequestParameter.Page, size: request.RequestParameter.PageSize, cancellationToken: cancellationToken);
                ProductListModel productListModel = _mapper.Map<ProductListModel>(products);
                return new SuccessDataResult<ProductListModel>(productListModel, Messages.ProductsListed);
            }
        }
    }
}
