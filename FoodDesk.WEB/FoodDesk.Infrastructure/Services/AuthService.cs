using FoodDesk.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace FoodDesk.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterAsync(string username, string email, string password, string confirmpassword, bool iscourier)
    {
        var user = new IdentityUser
        { 
            Email = email, 
            UserName = email 
        };
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return false;

        await _signInManager.SignInAsync(user, isPersistent: false);

        return true;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

        return result.Succeeded;
    }
}
