using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuth.ViewModels;

namespace RazorAuth.Pages.Account;

public class Login : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    [BindProperty] public LoginViewModel ViewModel { get; set; }

    public Login(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var result =
                await _signInManager.PasswordSignInAsync(ViewModel.Email, ViewModel.Password, ViewModel.RememberMe,
                    false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl) || returnUrl.Equals("/"))
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return RedirectToPage(returnUrl);
                }
            }
        }

        ModelState.AddModelError("", "Username or password incorrect");

        return Page();
    }
}