using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Pages.UserAccount
{
    public class LogoutModel(SignInManager<User> signInManager ) : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("../Index");
        }
    }
}
