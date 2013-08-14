namespace CrowdSourcedNews.Services.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;
    using CrowdSourcedNews.Mappers;

    public class UsersController : ApiController
    {
        private DbUsersRepository usersRepository;
        private IRepository<NewsArticle> newsArticlesRepository;
private                IRepository<Comment> commentsRepository;

        public UsersController(
            DbUsersRepository repository, 
            IRepository<NewsArticle> newsArticlesRepository, 
            IRepository<Comment> commentsRepository)
        {
            this.usersRepository = repository;
        }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisterModel userToRegister)
        {
            // Validate user info

            User newUser = null;
            try
            {
                UsersMapper.ToUserEntity(userToRegister);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user register model provided!");
            }

            usersRepository.Add(newUser);

            this.LoginUser(new UserLoginModel()
                { 
                    AuthCode = userToRegister.AuthCode, 
                    Username = userToRegister.Username 
                });

            // Return user logged model instance
            throw new NotImplementedException();
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage LoginUser(UserLoginModel userToLogin)
        {
            // Validate user info
            // Return user logged model instance
            throw new NotImplementedException();
        }

        
    }
}
