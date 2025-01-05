using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HtmxTestApp.BlazorWASM.Client.Attributes
{
    class RenderModeInteractiveWebAssembly : RenderModeAttribute
    {
        public override IComponentRenderMode Mode => RenderMode.InteractiveWebAssembly;
    }
}
