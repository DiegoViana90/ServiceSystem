using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceSystem.Data;
using ServiceSystem.Mapping;
using ServiceSystem.Models;
using ServiceSystem.Models.Request;

namespace ServiceSystem.Controllers 
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OrderMapping _orderMapping;

        public OrderController(AppDbContext context, OrderMapping orderMapping)
        {
            _context = context;
            _orderMapping = orderMapping;
        }

[HttpPost("insertOrder")]
public IActionResult InsertOrder([FromBody] OrderRequest orderRequest)
{
    if (orderRequest == null)
    {
        return BadRequest("Pedido não pode ser nulo");
    }

    try
    {
        Order order = _orderMapping.Map(orderRequest);
        MenuItem menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == order.MenuItemId);
        if (menuItem == null)
        {
            return BadRequest("Pedido inválido.");
        }
        order.TotalValue = menuItem.Value;

        return Ok("ok");
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
    }
}
    }
}
