using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.Api.Dtos;
using Order.Api.Infrastructure;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderContext _dbContext;

        public OrderController(OrderContext dbContext, ILogger<OrderController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDto orderDto)
        {
            var order = new Model.Order(orderDto.UserId, orderDto.PaymentForm)
            {
                DbContext = _dbContext
            };

            await order.Create(orderDto.ProductIdsQuantity);

            return Created(Request.Path.Value, order);
        }
    }
}
