using ETradeAPI.Application.Features.Categories.Queries;
using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Features.Products.Queries;
using ETradeAPI.Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ETradeAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductModel createProductModel)
        {
            CreateProductCommand createProductCommand = new() { CreateProductModel = createProductModel };
            var result = await Mediator.Send(createProductCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductModel updateProductModel)
        {
            UpdateProductCommand updateProductCommand = new() { UpdateProductModel = updateProductModel };
            var result = await Mediator.Send(updateProductCommand);
            return Ok(result);
        }
        [HttpPost("DeleteById/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteProductByIdCommand deleteProductByIdCommand)
        {
            var result = await Mediator.Send(deleteProductByIdCommand);
            return Ok(result);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdQuery getProductByIdQuery)
        {
            var result = await Mediator.Send(getProductByIdQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] RequestParameter requestParameter)
        {
            GetProductListQuery getProductListQuery = new() { RequestParameter = requestParameter };
            var result = await Mediator.Send(getProductListQuery);
            return Ok(result);
        }
        [HttpGet("GetPoductListByCategoryId")]
        public async Task<IActionResult> GetProductListByCategoryId([FromQuery] RequestParameter requestParameter, Guid categoryId )
        {
            GetProductListByCategoryIdQuery getProductListByCategoryIdQuery= new() { RequestParameter = requestParameter,CategoryId = categoryId };
            var result = await Mediator.Send(getProductListByCategoryIdQuery);
            return Ok(result);
        }
    }
} 
