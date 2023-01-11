using AutoMapper;
using ETradeAPI.Application.Features.Categories.Models;
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

namespace ETradeAPI.Application.Features.Categories.Queries
{
    public class GetProductListQuery : IRequest<IDataResult<ProductListModel>>
    {
        public RequestParameter RequestParameter { get; set; }

        public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IDataResult<ProductListModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetProductListQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _productRepository = ProductRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ProductListModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(include:m=>m.Include(c=>c.Category),
                    index: request.RequestParameter.Page, size: request.RequestParameter.PageSize,
                    orderBy: m=>m.OrderBy(p=>p.Category.Name), cancellationToken: cancellationToken);
                ProductListModel productListModel = _mapper.Map<ProductListModel>(products);
                return new SuccessDataResult<ProductListModel>(productListModel, Messages.ProductsListed);
            }
        }
    }
}
