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
public IActionResult InsertOrder([FromBody] CreateOrderRequest createOrderRequest)
{
    if (createOrderRequest == null)
    {
        return BadRequest("Pedido não pode ser nulo");
    }

    try
    {
        // Verificar se existe um pedido aberto para a mesa fornecida
        Order existingOrder = _context.Orders.FirstOrDefault(o => o.OrderStatus && o.ClosedDate == null && o.RestaurantTableId == createOrderRequest.RestaurantTableId);

        if (existingOrder != null)
        {
            // Atualizar o pedido existente com os novos dados
            _orderMapping.Map(createOrderRequest, existingOrder);

            // Calcular o TotalValue do novo pedido com base nos itens do pedido
            decimal totalValue = CalculateTotalValue(createOrderRequest);

            // Acrescentar o valor do novo pedido ao TotalValue existente
            existingOrder.TotalValue += totalValue;

            // Salvar as alterações no banco de dados
            _context.SaveChanges();

            // Retornar o pedido atualizado
            return Ok(existingOrder);
        }
        else
        {
            Order order = _orderMapping.Map(createOrderRequest);

            bool isFirstOrder = !_context.Orders.Any
            (o => o.RestaurantTableId == createOrderRequest.RestaurantTableId);

            if (isFirstOrder)
            {
                order.TotalValue = 0;
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
    }
}

        private decimal CalculateTotalValue(CreateOrderRequest createOrderRequest)
        {
            decimal totalValue = 0;
            foreach (var item in createOrderRequest.OrderItems)
            {
                MenuItem menuItem = _context.MenuItems.FirstOrDefault(m => m.MenuItemId == item.MenuItemId);
                totalValue += menuItem.Price * item.Quantity;
            }
            return totalValue;
        }
    }
}
