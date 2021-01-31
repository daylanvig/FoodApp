using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace Tests.FoodApp.Client.ClientTestHelpers
{
    public static class SaveFooterHelpers
    {
        private static IElement GetButton(IRenderedComponent<IComponent> component, string buttonType)
        {
            return component.FindAll($".save-footer button[data-button-type='{buttonType}']").SingleOrDefault();
        }

        public static IElement GetDeleteButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Delete");
        }

        public static IElement GetCancelButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Cancel");
        }

        public static IElement GetSaveButton(IRenderedComponent<IComponent> component)
        {
            return GetButton(component, "Save");
        }
    }
}
