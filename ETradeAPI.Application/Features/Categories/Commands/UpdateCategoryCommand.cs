using AutoMapper;
using ETradeAPI.Application.Features.Categories.Models;
using ETradeAPI.Application.Features.Categories.Rules;
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

namespace ETradeAPI.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand:IRequest<IDataResult<Category>>
    {
        public UpdateCategoryModel UpdateCategoryModel { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IDataResult<Category>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository = null, IMapper mapper = null, CategoryBusinessRules categoryBusinessRules = null)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }
            public async Task<IDataResult<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run();
                if (result != null)
                {
                    return new ErrorDataResult<Category>(result.Message);
                }
                Category category = _mapper.Map<Category>(request.UpdateCategoryModel);
                Category updatedCategory = await _categoryRepository.UpdateAsync(category);
                return new SuccessDataResult<Category>(updatedCategory,Messages.CategoryUpdated);
            }
        }
    }
}
