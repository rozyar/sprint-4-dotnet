using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas aos pedidos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="OrdersController"/>.
        /// </summary>
        /// <param name="orderService">Serviço de pedidos.</param>
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Obtém todos os pedidos.
        /// </summary>
        /// <returns>Uma lista de pedidos.</returns>
        /// <response code="200">Retorna a lista de pedidos.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        /// <summary>
        /// Obtém um pedido pelo ID.
        /// </summary>
        /// <param name="id">ID do pedido.</param>
        /// <returns>O pedido solicitado.</returns>
        /// <response code="200">Retorna o pedido.</response>
        /// <response code="404">Se o pedido não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="order">Dados do pedido a ser criado.</param>
        /// <returns>O pedido criado.</returns>
        /// <response code="201">Retorna o pedido criado.</response>
        /// <response code="400">Se os dados forem inválidos.</response>
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        /// <summary>
        /// Atualiza um pedido existente.
        /// </summary>
        /// <param name="id">ID do pedido a ser atualizado.</param>
        /// <param name="order">Dados atualizados do pedido.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se os dados forem inválidos.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        /// <summary>
        /// Exclui um pedido pelo ID.
        /// </summary>
        /// <param name="id">ID do pedido a ser excluído.</param>
        /// <response code="204">Se a exclusão for bem-sucedida.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
