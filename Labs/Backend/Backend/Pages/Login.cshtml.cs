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
                // 清除已經存在的登入 Cookie 內容
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
                    Msg = "帳號或密碼不正確";
                }
                //(bool result, string msg, Person person) = await personService.LoginAsync(Username, Password, true);
                if (result == true)
                {
                    string returnUrl = Url.Content("~/");

                    #region 加入這個使用者需要用到的 宣告類型 Claim Type
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

                    #region 建立 宣告式身分識別
                    // ClaimsIdentity類別是宣告式身分識別的具體執行, 也就是宣告集合所描述的身分識別
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    #endregion

                    #region 建立關於認證階段需要儲存的狀態
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        RedirectUri = this.Request.Host.Value
                    };
                    #endregion

                    #region 進行使用登入
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
                Msg = "帳號與密碼不可為空白";
            }
            return Page();
        }
    }
}
