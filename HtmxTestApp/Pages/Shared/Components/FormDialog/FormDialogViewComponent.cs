using HtmxTestApp.Domain.Services;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.FormDialog
{
    public class FormDialogViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(DialogOptionsModel model)
        {
            return View(model);
        }
    }
}
