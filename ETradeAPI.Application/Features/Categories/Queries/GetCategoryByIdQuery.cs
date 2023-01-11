using ETradeAPI.Application.RepositoryInterfaces;
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
    public class GetCategoryByIdQuery : IRequest<IDataResult<Category>>
    {
        public string Id { get; set; }

        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, IDataResult<Category>>
        {
            private readonly ICategoryRepository _categoryRepository;

            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IDataResult<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetByIdAsync(request.Id);
                if (category==null)
                {
                    return new ErrorDataResult<Category>(Messages.CategoryNotFound);
                }
                return new SuccessDataResult<Category>(category);
            }
        }
    }
}
