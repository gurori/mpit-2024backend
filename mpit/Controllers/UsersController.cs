using Microsoft.AspNetCore.Mvc;
using mpit.Application.Intefaces.Services;
using mpit.Core.DTO.User;

namespace mpit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController(
        IUserService userService)
            : BaseController
    {
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserRequest request) =>
            await TryCatchAsync(async () =>
            {
                Guid id = await _userService.RegisterAsync(request);
                Response.Cookies.Append("id", id.ToString());
                Response.Cookies.Append("role", request.Role);
                return Ok(id);
            });

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public Task<IActionResult> Get(Guid id) =>
            TryCatchAsync(async () =>
            {
                return Ok(await _userService.GetAsync(id));
            });
    }
}
