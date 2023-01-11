using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ETradeAPI.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinessRules(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IResult> ProductNameCannotDuplicateWhenInserted(string name)
        {
            Product? product = await _productRepository.GetSingleAsync(p => p.Name == name,enableTracking:false);
            if (product != null)
            {
                return new ErrorResult(Messages.ProductIsAlreadyExist);
            }
            return new SuccessResult();
        }
        public async Task<IResult> CheckIfProductIsExist(string id)
        {
            Product? product = await _productRepository.GetByIdAsync(id, tracking: false);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            return new SuccessResult();
        }
    }
}
