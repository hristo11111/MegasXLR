namespace CrowdSourcedNews.Services.Controllers
{
    using System;
    using System.Web.Http;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;
    using System.Net.Http;
    using CrowdSourcedNews.DataTransferObjects;
    using System.Net;
    using CrowdSourcedNews.Mappers;
    using System.Collections.Generic;
    using System.Linq;

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

        [HttpPost, ActionName("add")]
        public HttpResponseMessage PostNewsArticle(string sessionKey, [FromBody]NewsArticleModel newsArticle)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found!");
            }

            newsArticle.Author = user.Nickname;
            // Maybe pictures must be provided here

            NewsArticle newsArticleEntity = null;
            try
            {
                newsArticleEntity = NewsArticlesMapper
                    .ToNewsArticleEntity(newsArticle, usersRepository, commentsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid news article model provided!");
            }

            newsArticle.ID = newsArticleEntity.ID;

            this.newsArticlesRepository.Add(newsArticleEntity);

            return Request.CreateResponse(HttpStatusCode.Created, newsArticle);
        }

        [HttpGet, ActionName("get")]
        public HttpResponseMessage GetNewsArticle(string sessionKey, int id)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found!");
            }

            NewsArticle newsArticle = this.newsArticlesRepository.Get(id);
            if (newsArticle == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            NewsArticleModel newsArticleModel = null;
            try
            {
                newsArticleModel = NewsArticlesMapper.ToNewsArticleModel(newsArticle);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newsArticleModel);
            return response;
        }

        [HttpGet, ActionName("get")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found!");
            }

            ICollection<NewsArticleDetails> newsArticles = new List<NewsArticleDetails>();
            IQueryable<NewsArticle> newsArticlesEntities = this.newsArticlesRepository.GetAll();
            foreach (var newsArticle in newsArticlesEntities)
            {
                newsArticles.Add(NewsArticlesMapper.ToNewsArticleDetails(newsArticle));
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newsArticles);
            return response;
        }


    }
}
