namespace CrowdSourcedNews.Services.Controllers
{
    using System;
    using System.Net.Http;
    using System.Web.Http;
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    public class UsersController : ApiController
    {
        private DbUsersRepository usersRepository;

        public UsersController(DbUsersRepository repository)
        {
            this.usersRepository = repository;
        }

        [HttpPost]
        public HttpResponseMessage RegisterUser(UserRegisterModel user)
        {
            throw new NotImplementedException();
        }
    }
}
