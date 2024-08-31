using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RazorPagesGeneral.Model;
using RazorPagesGeneral.ViewModel;

namespace RazorPagesGeneral.Pages.UserAccount
{
    public class RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager) : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || RegisterViewModel is null)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(RegisterViewModel.Email);

            if(user is not null)
            {
                TempData["Error"] = "Этот Email уже занят";
                return Page();
            }

            if(RegisterViewModel.ConfirmPassword != RegisterViewModel.Password)
            {
                TempData["Error"] = "Пароли не совпадают";
                return Page();
            }

            var newUser = new User
            {
                Email = RegisterViewModel.Email,
                UserName = RegisterViewModel.Email
            };

            var newUserResponse = await userManager.CreateAsync(newUser, RegisterViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return RedirectToPage("../Index");
        }
    }
}
