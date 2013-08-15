namespace CrowdSourcedNews.Services.Controllers
{
    using System.Web.Http;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    public class NewsArticlesController : ApiController
    {
        private IRepository<NewsArticle> newsArticlesRepository;
        private DbUsersRepository usersRepository;
        private IRepository<Comment> commentsRepository;

        public NewsArticlesController(
            IRepository<NewsArticle> newsArticlesRepository,
            DbUsersRepository usersRepository,
            IRepository<Comment> commentsRepository)
        {
            this.newsArticlesRepository = newsArticlesRepository;
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
        }


    }
}
