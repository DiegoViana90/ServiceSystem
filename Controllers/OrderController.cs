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
        Order existingOrder = _context.Orders.FirstOrDefault(o => o.OrderStatus || (o.OrderStatus == false && o.ClosedDate != null)
            && o.TableNumber == createOrderRequest.TableNumber);

        if (existingOrder != null)
        {
            _orderMapping.Map(createOrderRequest, existingOrder);

            decimal totalValue = CalculateTotalValue(createOrderRequest);
            existingOrder.TotalValue += totalValue;

            _context.SaveChanges();

            return Ok(existingOrder);
        }
        else
        {
            Order newOrder = _orderMapping.Map(createOrderRequest);

            decimal totalValue = CalculateTotalValue(createOrderRequest);
            newOrder.TotalValue = totalValue;

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return Ok(newOrder);
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
    }
}

[HttpPost("closeOrder")]
public IActionResult CloseOrder(CloseOrderRequest closeOrderRequest)
{
    try
    {
        Order existingOrder = _context.Orders.FirstOrDefault(o => o.OrderStatus || (o.OrderStatus == false && o.ClosedDate != null)
            && o.TableNumber == closeOrderRequest.TableNumber);

        if (existingOrder != null)
        {
            decimal bill = existingOrder.TotalValue;
            DateTime creationDate = existingOrder.CreationDate;

            existingOrder.TotalValue = 0;
            existingOrder.OrderStatus = false;

            _context.SaveChanges();

            var response = new
            {
                RestaurantTableId = existingOrder.TableNumber,
                TotalBill = bill,
                CreationDate = creationDate,
                ClosedDate = DateTime.Now
            };

            return Ok(response);
        }
        else
        {
            return NotFound("Nenhum pedido aberto encontrado para a mesa fornecida.");
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
