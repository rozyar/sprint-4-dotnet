using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    /// <summary>
    /// Controlador para gerenciar produtos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        /// <summary>
        /// Construtor do controlador de produtos.
        /// </summary>
        /// <param name="productService">Serviço de produtos injetado.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Obtém todos os produtos disponíveis.
        /// </summary>
        /// <returns>Uma lista de produtos.</returns>
        /// <response code="200">Retorna a lista de produtos.</response>
        // GET: api/Products
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        
        /// <summary>
        /// Obtém um produto específico pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>O produto solicitado.</returns>
        /// <response code="200">Retorna o produto.</response>
        /// <response code="404">Se o produto não for encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="product">Dados do produto a ser criado.</param>
        /// <returns>O produto criado.</returns>
        /// <response code="201">Produto criado com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Product), 201)]
        public async Task<IActionResult> Create(Product product)
        {
            await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="product">Dados atualizados do produto.</param>
        /// <response code="204">Produto atualizado com sucesso.</response>
        /// <response code="400">Se os dados forem inválidos.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        /// <summary>
        /// Remove um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <response code="204">Produto removido com sucesso.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
