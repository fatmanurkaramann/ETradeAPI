using AutoMapper;
using ETradeAPI.Application.Features.Categories.Models;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Requests;
using ETradeAPI.Core.Wrappers.Paging;
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

namespace ETradeAPI.Application.Features.Categories.Queries
{
    public class GetCategoryListQuery : IRequest<IDataResult<CategoryListModel>>
    {
        public RequestParameter RequestParameter { get; set; }

        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IDataResult<CategoryListModel>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<CategoryListModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryRepository.GetListAsync(
                    index: request.RequestParameter.Page, size: request.RequestParameter.PageSize, cancellationToken: cancellationToken);
                CategoryListModel categoryListModel = _mapper.Map<CategoryListModel>(categories);
                return new SuccessDataResult<CategoryListModel>(categoryListModel, Messages.CategoriesListed);
            }
        }
    }
}
