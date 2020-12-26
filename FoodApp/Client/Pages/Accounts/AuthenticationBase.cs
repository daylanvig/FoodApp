using Microsoft.AspNetCore.Components;

namespace FoodApp.Client.Pages.Accounts
{
    public class AuthenticationBase : ComponentBase
    {
        [Parameter]
        public string Action { get; set; }
    }
}
