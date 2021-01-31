using Microsoft.AspNetCore.Components;

namespace FoodApp.Client.Components.Shared.Elements
{
    public partial class FormTitle : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }
    }
}
