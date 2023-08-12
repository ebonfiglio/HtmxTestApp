using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace HtmxTestApp.Blazor.Components.Teams
{
    public partial class TeamFormDialog
    {
        [Parameter]
        public EventCallback<Team> OnSubmit { get; set; }

        [Parameter]
        public Team? Team { get; set; }

    }
}
