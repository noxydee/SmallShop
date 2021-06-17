using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Zajecia_PS04.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Web;
using Zajecia_PS04.DAL;
using Microsoft.AspNetCore.Identity;


namespace Zajecia_PS04.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        private IConfiguration _configuration;

        public string Message { get; set; }

        private IUser _UserDB;
        private List<SiteUser> ListOfUsers { get; set; }

        [BindProperty]
        public SiteUser user { get; set; }

        public UserLoginModel(IConfiguration _configuration, IUser _UserDB)
        {                                                                  
            this._configuration = _configuration;                          
            this._UserDB = _UserDB;                                        
            ListOfUsers = _UserDB.List();                                  
        }                                                                  

        private bool ValidateUser(SiteUser user)
        {
            PasswordHasher<string> PasswordHasher = new PasswordHasher<string>();

            foreach (SiteUser checker in ListOfUsers)
            {
                if (user.UserName == checker.UserName && PasswordHasher.VerifyHashedPassword(user.UserName, checker.password, user.password) == PasswordVerificationResult.Success)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ValidateUser(user))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var ClaimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(ClaimsIdentity));

                if (returnUrl == null)
                {
                    return RedirectToPage("../List");
                }
                return Redirect(returnUrl);
            }
            return Page();
        }

        public void OnGet()
        {
            
        }
    }
}
