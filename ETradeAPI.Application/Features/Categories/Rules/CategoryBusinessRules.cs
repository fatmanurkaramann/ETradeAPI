using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Wrappers.Paging;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> CategoryNameCannotBeDuplicatedWhenInserted(string name)
        {
            var result = await _categoryRepository.GetSingleAsync(c => c.Name == name);
            if (result!=null)
            {
                return new ErrorResult(Messages.CategoryNameIsAlreadyExist);
            }
            return new SuccessResult();
        }
        public async Task<IResult> CategoryIsExist(string categoryId)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);
            if (result == null)
            {
                return new ErrorResult(Messages.CategoryDoesnotExist);
            }
            return new SuccessResult();
        }
    }
}
