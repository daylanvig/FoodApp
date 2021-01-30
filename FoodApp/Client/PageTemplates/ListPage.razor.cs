using Microsoft.AspNetCore.Components;

namespace FoodApp.Client.PageTemplates
{
    public partial class ListPage : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback OnAddClick { get; set; }
        [Parameter]
        public bool IsSaveVisible { get; set; }
    }
}
