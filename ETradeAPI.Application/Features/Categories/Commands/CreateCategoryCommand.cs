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
    public class CreateCategoryCommand : IRequest<IDataResult<Category>>
    {
        public CreateCategoryModel CreateCategoryModel { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IDataResult<Category>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper = null, CategoryBusinessRules categoryBusinessRules = null)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(
                    await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(request.CreateCategoryModel.Name)
                    );
                if (result != null)
                {
                    return new ErrorDataResult<Category>(result.Message);
                }
                Category category = _mapper.Map<Category>(request.CreateCategoryModel);
                Category createdCategory = await _categoryRepository.AddAsync(category);
                return new SuccessDataResult<Category>(createdCategory, Messages.CategoryCreated);
            }
        }
    }
}
