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
                await _userService.RegisterAsync(request);
                return Ok();
            });

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            return Ok(await _userService.GetAllAsync());
        }
    }
}
