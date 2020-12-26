using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Accounts
{
    public class LoginDisplayBase : ComponentBase
    {
        [Inject] SignOutSessionStateManager SignoutManager { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected async Task BeginSignOut(MouseEventArgs e)
        {
            await SignoutManager.SetSignOutState();
            NavigationManager.NavigateTo("authentication/logout");
        }
    }
}
