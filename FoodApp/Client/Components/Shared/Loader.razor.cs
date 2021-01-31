using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FoodApp.Client.Components.Shared
{
    /// <summary>
    /// General Loader Component
    /// </summary>
    /// <remarks>
    /// While IsLoaded is false, this displays a loader in the place where the child content will display.
    /// When it's true, the loader hides to display content.
    /// </remarks>
    public partial class Loader : ComponentBase
    {
        [Parameter]
        public bool IsLoaded { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public Size Size { get; set; } = Size.Medium;
    }
}
