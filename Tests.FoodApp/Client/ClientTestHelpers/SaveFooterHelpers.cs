using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace Tests.FoodApp.Client.ClientTestHelpers
{
    /// <summary>
    /// TestHelpers for querying components with a SaveFooter
    /// </summary>
    public static class SaveFooterHelpers
    {
        private static IElement GetButton(IRenderedComponent<IComponent> component, string buttonType)
        {
            return component.FindAll($".save-footer button[data-button-type='{buttonType}']").SingleOrDefault();
        }

        /// <summary>
        /// Get delete button from footer
        /// </summary>
        /// <param name="component"></param>
        /// <returns>Delete button if found, else null</returns>
        public static IElement GetDeleteButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Delete");
        }

        /// <summary>
        /// Get cancel button from footer
        /// </summary>
        /// <param name="component"></param>
        /// <returns>Cancel button if found, else null</returns>
        public static IElement GetCancelButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Cancel");
        }

        /// <summary>
        /// Get save button from a save footer
        /// </summary>
        /// <param name="component"></param>
        /// <returns>Save button if found, else null</returns>
        public static IElement GetSaveButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Save");
        }
    }
}
