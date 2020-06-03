using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyncfusionLab.DataModels;
using SyncfusionLab.DTOs;
using SyncfusionLab.Services;

namespace SyncfusionLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IPersonService Service { get; }
        public LoginController(IPersonService service)
        {
            Service = service;
        }

        [HttpPost]
        public StandardResponse<LoginQueryString> Post([FromBody] LoginQueryString loginQueryString)
        {
            StandardResponse<LoginQueryString> standardResponse = new StandardResponse<LoginQueryString>();

            if (loginQueryString != null)
            {
                if (string.IsNullOrEmpty(loginQueryString.Account) ||
                    string.IsNullOrEmpty(loginQueryString.Password))
                {
                    standardResponse.ErrorMessage = "帳號或密碼沒有發現";
                }
                else if (loginQueryString.Account == "admin" &&
                    loginQueryString.Password == "123")
                {
                    standardResponse.Success = true;
                    standardResponse.Payload = loginQueryString;
                }
                else
                {
                    standardResponse.ErrorMessage = "帳號或密碼不正確";
                }
            }
            else
            {
                standardResponse.ErrorMessage = "沒有接收到使用者身分驗證資料";
            }
            return standardResponse;
        }
    }
}
