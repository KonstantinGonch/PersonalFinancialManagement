using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinancialManagement.DbMiddleware;
using PersonalFinancialManagement.Models;
using PersonalFinancialManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Регистрация в системе
        /// </summary>
        /// <returns>Данные о зарегистрированном профиле</returns>
        [HttpPost]
        [Route("register")]
        public async Task<BaseApiResponse<Profile>> Register(Profile profile)
        {
            using (var dbContext = new AppDataContext())
            {
                var user = dbContext.Profiles.FirstOrDefault(p => p.Login == profile.Login);
                if (user != null)
                {
                    return new BaseApiResponse<Profile>
                    {
                        Success = false,
                        ErrorMessage = "Пользователь с таким логином уже существует"
                    };
                }
                dbContext.Profiles.Add(profile);
                await dbContext.SaveChangesAsync();
            }
            return new BaseApiResponse<Profile>
            {
                Success = true,
                Data = profile
            };
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Описание профиля</returns>
        [HttpGet]
        [Route("auth")]
        public async Task<BaseApiResponse<Profile>> Auth(string login, string password)
        {
            using (var dbContext = new AppDataContext())
            {
                var profile = dbContext.Profiles.FirstOrDefault(p => p.Login == login && p.Password == password);
                if (profile != null)
                {
                    await Authenticate(login);
                    return new BaseApiResponse<Profile>
                    {
                        Success = true,
                        Data = profile
                    };
                }
                else
                {
                    return new BaseApiResponse<Profile>
                    {
                        Success = false,
                        ErrorMessage = "Пользователь не найден",
                    };
                }
            }
        }

        /// <summary>
        /// Выход из учетной записи
        /// </summary>
        [HttpGet]
        [Route("signout")]
        public void SignOut()
        {
            Logout();
        }

        [Authorize]
        [HttpGet]
        [Route("test")]
        public BaseApiResponse<string> Test()
        {
            return new BaseApiResponse<string>
            {
                Success = true,
                Data = "Test"
            };
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private async void Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
