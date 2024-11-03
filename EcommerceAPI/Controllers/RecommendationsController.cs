using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    /// <summary>
    /// Controlador responsável pelas recomendações de produtos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="RecommendationsController"/>.
        /// </summary>
        /// <param name="recommendationService">Serviço de recomendações.</param>
        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        /// <summary>
        /// Obtém recomendações de produtos para um usuário específico.
        /// </summary>
        /// <param name="userId">ID do usuário.</param>
        /// <returns>Uma lista de recomendações de produtos.</returns>
        /// <response code="200">Retorna a lista de recomendações.</response>
        /// <response code="400">Se não houver dados disponíveis ou ocorrer um erro.</response>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetRecommendations(int userId)
        {
            try
            {
                var recommendations = await _recommendationService.GetRecommendationsAsync(userId);
                return Ok(recommendations);
            }
            catch (InvalidOperationException ex)
            {
                // Trata o caso quando não há dados disponíveis
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}