using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YourNamespace.Pages
{
    public class Playermodel : PageModel
    {
        public PlayerInfoResponse PlayerData { get; set; }

        public void OnGet()
        {
            // Initialize PlayerData or perform any necessary operations here
        }
    }
}