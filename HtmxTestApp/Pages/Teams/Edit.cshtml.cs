using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Teams
{
    public class EditModel : PageModel
    {
        public Guid TeamId { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid teamId);
            if (!isValid) return Redirect("Error");
            TeamId = teamId;

            return Page();
        }
    }
}
