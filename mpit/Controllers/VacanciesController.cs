using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mpit.Application.Services;
using mpit.Core.DTO;

namespace mpit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class VacanciesController(
        VacancyService vacancyService)
            : BaseController
    {
        private readonly VacancyService _vacancyService = vacancyService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateVacancyRequest request) =>
            await TryCatchAsync(async () =>
            {
                await _vacancyService.CreateAsync(request);
                return Ok();
            });

        [HttpGet]
        public async Task<IActionResult> Get() =>
            await TryCatchAsync(async () =>
            {
                return Ok(await _vacancyService.GetAsync());
            });

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) =>
            await TryCatchAsync(async () =>
            {
                return Ok(await _vacancyService.GetAsync(id));
            });
    }
}
