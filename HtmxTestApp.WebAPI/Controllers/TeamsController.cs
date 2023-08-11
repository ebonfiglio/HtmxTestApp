using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
                _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            List<Team> teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teamService.DeleteAsync(id);
            return Ok();
        }
    }
}
