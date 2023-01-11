using ETradeAPI.Application.Features.Categories.Commands;
using ETradeAPI.Application.Features.Categories.Models;
using ETradeAPI.Application.Features.Categories.Queries;
using ETradeAPI.Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryModel createCategoryModel)
        {
            CreateCategoryCommand createCategoryCommand = new() { CreateCategoryModel = createCategoryModel };
            var result = await Mediator.Send(createCategoryCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryModel updateCategoryModel)
        {
            UpdateCategoryCommand updateCategoryCommand = new() { UpdateCategoryModel = updateCategoryModel };
            var result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }
        [HttpPost("DeleteById/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteCategoryByIdCommand deleteCategoryByIdCommand)
        {
            var result = await Mediator.Send(deleteCategoryByIdCommand);
            return Ok(result);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryByIdQuery getCategoryByIdQuery)
        {
            var result = await Mediator.Send(getCategoryByIdQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            RequestParameter requestParameter = new RequestParameter() { Page = 0, PageSize = int.MaxValue };
            GetCategoryListQuery getCategoryListQuery = new() { RequestParameter = requestParameter };
            var result = await Mediator.Send(getCategoryListQuery);
            return Ok(result);

        }

    }
}
