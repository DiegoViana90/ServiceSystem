using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceSystem.Data;
using ServiceSystem.Mapping;
using ServiceSystem.Models;
using ServiceSystem.Models.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceSystem.Controllers
{
    [ApiController]
    [Route("v1/MenuItems")]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly MenuItemMapping _menuItemMapping;

        public MenuItemController(AppDbContext context, MenuItemMapping menuItemMapping)
        {
            _context = context;
            _menuItemMapping = menuItemMapping;
        }

        [HttpPost("insertMenuItem")]
        [SwaggerOperation(Summary = "Inserir um novo item de menu.")]
        [SwaggerResponse(200, "OK", typeof(MenuItem))]
        [SwaggerResponse(400, "BadRequest", typeof(string))]
        [SwaggerResponse(500, "InternalServerError", typeof(string))]
        public IActionResult InsertMenuItem([FromBody] CreateMenuItemRequest createMenuItemRequest)
        {
            if (createMenuItemRequest == null)
            {
                return BadRequest("MenuItem não pode ser nulo");
            }

            try
            {
                MenuItem newMenuItem = _menuItemMapping.Map(createMenuItemRequest);
                _context.MenuItems.Add(newMenuItem);
                _context.SaveChanges();

                return Ok(newMenuItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("updateMenuItem")]
        [SwaggerOperation(Summary = "Atualizar um item de menu existente.")]
        [SwaggerResponse(200, "OK", typeof(MenuItem))]
        [SwaggerResponse(400, "BadRequest", typeof(string))]
        [SwaggerResponse(404, "NotFound", typeof(string))]
        [SwaggerResponse(500, "InternalServerError", typeof(string))]
        public IActionResult UpdateMenuItem(int id, [FromBody] UpdateMenuItemRequest updateMenuItemRequest)
        {
            try
            {
                MenuItem menuItem = _context.MenuItems.FirstOrDefault(m => m.MenuItemId == id);
                if (menuItem != null)
                {
                    if (updateMenuItemRequest.Price == 0)
                    {
                        return BadRequest("O preço do item do menu não pode ser zero.");
                    }

                    _menuItemMapping.Map(updateMenuItemRequest, menuItem);
                    _context.SaveChanges();
                    return Ok(menuItem);
                }
                else
                {
                    return NotFound("MenuItem não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
        
        [HttpGet("getMenuItems")]
        [SwaggerOperation(Summary = "Obter todos os itens de menu.")]
        [SwaggerResponse(200, "OK", typeof(MenuItem[]))]
        [SwaggerResponse(500, "InternalServerError", typeof(string))]
        public IActionResult GetMenuItems()
        {
            try
            {
                var menuItems = _context.MenuItems.ToArray();
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
