using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;

namespace MainHomeApplication.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        //public async Task<IActionResult> OnPostAsync(string? returnUrl, string email, string password)
        //{
        //    ServiceUser? user = ServiceUser.users.FirstOrDefault(user => user.Email == email && user.Password == password);
        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }
        //    var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email),
        //                                   new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
        //                                   new Claim(ClaimTypes.Gender,user.Gender),
        //                                   new Claim("access-level",user.AccessLevel)};
        //    ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
        //    await PageContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        //    Console.WriteLine(returnUrl);
        //    return Redirect(returnUrl ?? "/Index");
        //}
    }
}
