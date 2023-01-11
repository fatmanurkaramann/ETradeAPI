using ETradeAPI.Application.Features.Categories.Rules;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.BusinessRules;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using MediatR;

namespace ETradeAPI.Application.Features.Categories.Commands
{
    public class DeleteCategoryByIdCommand : IRequest<IResult>
    {
        public string Id { get; set; }

        public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand, IResult>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public DeleteCategoryByIdCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IResult> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(await _categoryBusinessRules.CategoryIsExist(request.Id));
                if (result != null)
                    return new ErrorResult(result.Message);
                var deleteResult = await _categoryRepository.DeleteByIdAsync(request.Id);
                if (deleteResult<=0)
                {
                    return new ErrorResult();
                }
                return new SuccessResult(Messages.CategoryDeleted);

            }
        }
    }
}
