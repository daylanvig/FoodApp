using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Shared
{
    /// <summary>
    /// Shared form layout
    /// </summary>
    public partial class ModelForm : ComponentBase
    {
        #region Parameters
        [Parameter]
        public bool IsNew { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }
        #endregion
        #region Fields
        private MudForm _form;
        #endregion
        #region LifeCycle
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (_form != null)
            {
                _form.ResetValidation();
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Invoke Save Changes
        /// </summary>
        /// <returns></returns>
        private Task Save() => OnSave.InvokeAsync();
        /// <summary>
        /// Invoke Cancel and Clear
        /// </summary>
        /// <returns></returns>
        private async Task Cancel()
        {
            if (OnCancel.HasDelegate)
            {
                await OnCancel.InvokeAsync();
            }
            _form.Reset();
        }
        /// <summary>
        /// Invoke Delete action
        /// </summary>
        /// <returns></returns>
        private Task Delete() => OnDelete.InvokeAsync();
        #endregion
    }
}
