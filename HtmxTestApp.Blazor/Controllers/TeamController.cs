using HtmxTestApp.Blazor.Components.Team;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Blazor.Controllers
{
    public class TeamController : Controller
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerFactory _loggerFactory;

        public TeamController(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _loggerFactory = loggerFactory;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/Team/Dialog/Show")]
        public async Task<IActionResult> ShowAsync()
        {
            var htmlRenderer = new HtmlRenderer(_serviceProvider, _loggerFactory);
            // Render a Blazor component (e.g. DialogComponent) to HTML
            var renderedHtml = await htmlRenderer.RenderComponentAsync<TeamDialog>(
                ParameterView.Empty
            );

            // Return the rendered HTML as content
            return Content(renderedHtml.ToString(), "text/html");
        }
    }
}
