using Microsoft.AspNetCore.Components;

namespace FoodApp.Client.Components.Shared
{
    public partial class SaveFooter
    {
        public const string SAVE_LABEL = "Save Changes";
        public const string ADD_LABEL = "Add Now";

        [Parameter]
        public EventCallback OnSaveClick { get; set; }
        [Parameter]
        public bool IsSaveVisible { get; set; } = true;
        [Parameter]
        public string SaveLabel { get; set; } = SAVE_LABEL;

        [Parameter]
        public EventCallback OnDeleteClick { get; set; }
        [Parameter]
        public bool IsDeleteVisible { get; set; }
        [Parameter]
        public EventCallback OnCancelClick { get; set; }
        [Parameter]
        public bool IsCancelVisible { get; set; }

    }
}
