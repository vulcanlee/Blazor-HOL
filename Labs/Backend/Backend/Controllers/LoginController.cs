using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Backend.DTOs;
using Backend.Factories;
using Backend.Enums;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        int UserID;
        int TokenVersion;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(LoginRequestDTO loginRequestDTO)
        {
            if (ModelState.IsValid == false)
            {
                APIResult apiResult = APIResultFactory.Build(false, StatusCodes.Status200OK,
                 ErrorMessageEnum.傳送過來的資料有問題);
                return Ok(apiResult);
            }
            if (loginRequestDTO.Account != "admin" && loginRequestDTO.Account != "user")
            {
                APIResult apiResult = APIResultFactory.Build(false, StatusCodes.Status400BadRequest,
                 ErrorMessageEnum.帳號或密碼不正確);
                return BadRequest(apiResult);
            }

            {
                string token = GenerateToken(loginRequestDTO);
                string refreshToken = GenerateRefreshToken(loginRequestDTO);

                LoginResponseDTO LoginResponseDTO = new LoginResponseDTO()
                {
                    Account = loginRequestDTO.Account,
                    Id = 0,
                    Name = loginRequestDTO.Account,
                    Token = token,
                    TokenExpireMinutes = Convert.ToInt32(configuration["Tokens:JwtExpireMinutes"]),
                    RefreshToken = refreshToken,
                    RefreshTokenExpireDays = Convert.ToInt32(configuration["Tokens:JwtRefreshExpireDays"]),
                };

                APIResult apiResult = APIResultFactory.Build(true, StatusCodes.Status200OK,
                    ErrorMessageEnum.None, payload: LoginResponseDTO);
                return Ok(apiResult);
            }

        }

        [Authorize(Roles = "RefreshToken")]
        [Route("RefreshToken")]
        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            APIResult apiResult;

            LoginRequestDTO loginRequestDTO = new LoginRequestDTO()
            {
                Account = User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value,
            };
            string token = GenerateToken(loginRequestDTO);
            string refreshToken = GenerateRefreshToken(loginRequestDTO);

            LoginResponseDTO LoginResponseDTO = new LoginResponseDTO()
            {
                Account = loginRequestDTO.Account,
                Id = 0,
                Name = loginRequestDTO.Account,
                Token = token,
                TokenExpireMinutes = Convert.ToInt32(configuration["Tokens:JwtExpireMinutes"]),
                RefreshToken = refreshToken,
                RefreshTokenExpireDays = Convert.ToInt32(configuration["Tokens:JwtRefreshExpireDays"]),
            };

            apiResult = APIResultFactory.Build(true, StatusCodes.Status200OK,
               ErrorMessageEnum.None, payload: LoginResponseDTO);
            return Ok(apiResult);

        }

        public string GenerateToken(LoginRequestDTO loginRequestDTO)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, loginRequestDTO.Account),
                new Claim(ClaimTypes.Name, loginRequestDTO.Account),
                new Claim(ClaimTypes.Role, "User"),
            };
            if (loginRequestDTO.Account == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }

            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:ValidIssuer"],
                audience: configuration["Tokens:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Tokens:JwtExpireMinutes"])),
                //notBefore: DateTime.Now.AddMinutes(-5),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(configuration["Tokens:IssuerSigningKey"])),
                        SecurityAlgorithms.HmacSha512)
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }

        public string GenerateRefreshToken(LoginRequestDTO loginRequestDTO)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, loginRequestDTO.Account),
                new Claim(ClaimTypes.Name, loginRequestDTO.Account),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Role, $"RefreshToken"),
            };

            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:ValidIssuer"],
                audience: configuration["Tokens:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToDouble(configuration["Tokens:JwtRefreshExpireDays"])),
                //notBefore: DateTime.Now.AddMinutes(-5),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(configuration["Tokens:IssuerSigningKey"])),
                        SecurityAlgorithms.HmacSha512)
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}
