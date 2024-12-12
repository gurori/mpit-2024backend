using Microsoft.AspNetCore.Mvc;
using mpit.Application.Intefaces.Repositories;

namespace mpit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController(
        IUserRepository userRepo)
            : BaseController
    {
        private readonly IUserRepository _userRepo = userRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            return Ok(await _userRepo.GetAll());
        }
    }
}
