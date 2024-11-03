using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas aos usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UsersController"/>.
        /// </summary>
        /// <param name="userService">Serviço de usuários.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        /// <response code="200">Retorna a lista de usuários.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>O usuário solicitado.</returns>
        /// <response code="200">Retorna o usuário.</response>
        /// <response code="404">Se o usuário não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Obtém um usuário pelo e-mail.
        /// </summary>
        /// <param name="email">E-mail do usuário.</param>
        /// <returns>O usuário solicitado.</returns>
        /// <response code="200">Retorna o usuário.</response>
        /// <response code="404">Se o usuário não for encontrado.</response>
        [HttpGet("Email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">Dados do usuário a ser criado.</param>
        /// <returns>O usuário criado.</returns>
        /// <response code="201">Retorna o usuário criado.</response>
        /// <response code="400">Se os dados forem inválidos.</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="user">Dados atualizados do usuário.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se os dados forem inválidos.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <response code="204">Se a exclusão for bem-sucedida.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
