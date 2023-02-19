using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.GamesForm
{
    public class GamesFormViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid? id)
        {
            return View();
        }
    }
}
