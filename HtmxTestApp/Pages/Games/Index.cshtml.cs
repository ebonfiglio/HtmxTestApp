using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly IGameService gameService;

        public List<Game> Games = new();
        public IndexModel(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public void OnGet()
        {
            Games = gameService.GetAll();
        }
    }
}
