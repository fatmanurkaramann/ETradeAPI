using ETradeAPI.Application.Features.Orders.Commands;
using ETradeAPI.Application.Features.Orders.Models;
using ETradeAPI.Application.Features.Orders.Queries;
using ETradeAPI.Core.Requests;
using ETradeAPI.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderModel createOrderModel)
        {
            CreateOrderCommand createOrderCommand = new() { CreateOrderModel = createOrderModel };
            var result = await Mediator.Send(createOrderCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateOrderModel updateOrderModel)
        {
            UpdateOrderCommand updateOrderCommand = new() { UpdateOrderModel = updateOrderModel };
            var result = await Mediator.Send(updateOrderCommand);
            return Ok(result);
        }
        [HttpPost("DeleteById/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteOrderByIdCommand deleteOrderByIdCommand)
        {
            var result = await Mediator.Send(deleteOrderByIdCommand);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] RequestParameter requestParameter)
        {
            GetOrderListQuery getOrderListQuery = new() { RequestParameter = requestParameter };
            var result = await Mediator.Send(getOrderListQuery);
            return Ok(result);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderByIdQuery getOrderByIdQuery)
        {
            var result = await Mediator.Send(getOrderByIdQuery);
            return Ok(result);
        }
        [HttpGet("GetListByUserId")]
        public async Task<IActionResult> GetListByUserId([FromQuery] RequestParameter requestParameter , Guid userId)
        {
            GetOrderListByUserIdQuery getOrderListByUserIdQuery
                = new() { RequestParameter = requestParameter, UserId = userId };
            var result = await Mediator.Send(getOrderListByUserIdQuery);
            return Ok(result);
        }
    }
}
