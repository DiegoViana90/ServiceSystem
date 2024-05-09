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
                // Mapear os dados do pedido recebidos na solicitação HTTP para a entidade de pedido
                Order order = _orderMapping.Map(createOrderRequest);

                // Aqui você pode implementar a lógica para calcular o total do pedido com base nos itens do pedido
                decimal totalValue = 0;
                foreach (var item in createOrderRequest.OrderItems)
                {
                    MenuItem menuItem = _context.MenuItems.FirstOrDefault(m => m.MenuItemId == item.MenuItemId);
                    totalValue += menuItem.Price * item.Quantity;
                }
                order.TotalValue = totalValue;

                // Adicionar o pedido ao contexto do banco de dados
                _context.Orders.Add(order);

                // Salvar as alterações no banco de dados
                _context.SaveChanges();

                // Retornar o pedido criado com sucesso
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
