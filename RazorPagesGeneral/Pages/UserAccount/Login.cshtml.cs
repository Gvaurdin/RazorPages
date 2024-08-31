using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Model;
using RazorPagesGeneral.ViewModel;

namespace RazorPagesGeneral.Pages.UserAccount
{
    public class LoginModel(UserManager<User> userManager, SignInManager<User> signInManager) : PageModel
    {
        [BindProperty]
        public LoginView? loginViewModel { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || loginViewModel is null)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user is not null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (passwordCheck)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToPage("../Index");
                    }
                }
            }

            TempData["Error"] = "Вы ввели неправильные данные";

            return Page();
        }
    }
}
