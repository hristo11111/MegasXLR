using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CrowdSourcedNews.DataTransferObjects;
using CrowdSourcedNews.Repositories;

namespace CrowdSourcedNews.Services.Controllers
{
    public class UserController
    {
        [HttpPost]
        [ActionName("register")]
        public UserLoggedModel RegisterUser(UserRegisterModel user)
        {
            UsersRepository.CreateUser(user.Username, user.Nickname, user.AuthCode);
            string nickname = string.Empty;
            var sessionKey = UsersRepository.LoginUser(user.Username, user.AuthCode, out nickname);
            return new UserLoggedModel()
            {
                Nickname = nickname,
                SessionKey = sessionKey
            };
        }

        [HttpPost]
        [ActionName("login")]
        public UserLoggedModel LoginUser(UserLoginModel user)
        {

            string nickname = string.Empty;
            var sessionKey = UsersRepository.LoginUser(user.Username, user.AuthCode, out nickname);
            return new UserLoggedModel()
            {
                Nickname = nickname,
                SessionKey = sessionKey
            };
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            UsersRepository.LogoutUser(sessionKey);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}