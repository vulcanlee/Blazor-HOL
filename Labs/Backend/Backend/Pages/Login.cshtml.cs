using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Backend.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public LoginModel()
        {
#if DEBUG
            Username = "user";
            Password = "123";
            PasswordType = "";
#endif
        }
        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";
        public string PasswordType { get; set; } = "password";
        public string Msg { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                // �M���w�g�s�b���n�J Cookie ���e
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
        }
        public string ReturnUrl { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) == false && string.IsNullOrEmpty(Password) == false)
            {
                bool result = true;
                string msg = "";
                if (Username != "admin" && Username != "user")
                {
                    result = false;
                    Msg = "�b���αK�X�����T";
                }
                //(bool result, string msg, Person person) = await personService.LoginAsync(Username, Password, true);
                if (result == true)
                {
                    string returnUrl = Url.Content("~/");

                    #region �[�J�o�ӨϥΪ̻ݭn�Ψ쪺 �ŧi���� Claim Type
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "User"),
                        new Claim(ClaimTypes.Name, Username),
                    };
                    if (Username == "admin")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                    }
                    #endregion

                    #region �إ� �ŧi�������ѧO
                    // ClaimsIdentity���O�O�ŧi�������ѧO���������, �]�N�O�ŧi���X�Ҵy�z�������ѧO
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    #endregion

                    #region �إ�����{�Ҷ��q�ݭn�x�s�����A
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        RedirectUri = this.Request.Host.Value
                    };
                    #endregion

                    #region �i��ϥεn�J
                    try
                    {
                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                    #endregion

                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                Msg = "�b���P�K�X���i���ť�";
            }
            return Page();
        }
    }
}
