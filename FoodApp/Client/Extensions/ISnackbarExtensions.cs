using MudBlazor;

namespace FoodApp.Client.Extensions
{
    // TODO -> support for custom messages as needed
    /// <summary>
    /// ISnackbar Extension Methods
    /// </summary>
    public static class ISnackbarExtensions
    {
        #region Private Helpers
        /// <summary>
        /// Internal helper for shared logic
        /// </summary>
        /// <param name="snackbar"></param>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        private static void ShowSnackbar(ISnackbar snackbar, string message, Severity severity)
        {
            snackbar.Add(message, severity);
        }
        #endregion
        #region General
        /// <summary>
        /// Show a success snackbar with message
        /// </summary>
        /// <param name="snackbar"></param>
        /// <param name="message"></param>
        public static void ShowSuccess(this ISnackbar snackbar, string message)
        {
            ShowSnackbar(snackbar, message, Severity.Success);
        }

        /// <summary>
        /// Show an error snackbar with a message
        /// </summary>
        /// <param name="snackbar"></param>
        /// <param name="message"></param>
        public static void ShowError(this ISnackbar snackbar, string message)
        {
            ShowSnackbar(snackbar, message, Severity.Error);
        }
        #endregion
        #region Save
        /// <summary>
        /// Helper to show general save successful snackbar
        /// </summary>
        /// <param name="snackbar"></param>
        /// <param name="itemName"></param>
        public static void ShowSaveSuccess(this ISnackbar snackbar, string itemName)
        {
            ShowSnackbar(snackbar, $"\"{itemName}\" successfully saved!", Severity.Success);
        }

        /// <summary>
        /// Helper to show general message when save fails
        /// </summary>
        /// <param name="snackbar"></param>
        public static void ShowSaveFailed(this ISnackbar snackbar)
        {
            // future -> detailed message support
            ShowSnackbar(snackbar, "Failed to save", Severity.Error);
        }
        #endregion
        #region Delete
        /// <summary>
        /// Helper to show delete was successful
        /// </summary>
        /// <param name="snackbar"></param>
        /// <param name="itemName"></param>
        public static void ShowDeleteSuccess(this ISnackbar snackbar, string itemName)
        {
            ShowSnackbar(snackbar, $"\"{itemName}\" successfully deleted!", Severity.Success);
        }

        /// <summary>
        /// Helper to show deletion failed
        /// </summary>
        /// <param name="snackbar"></param>
        public static void ShowDeleteFailed(this ISnackbar snackbar)
        {
            // todo -> detailed error message support
            ShowSnackbar(snackbar, "Failed to delete", Severity.Error);
        }
        #endregion
    }
}
