namespace CrowdSourcedNews.Services.DependencyResolvers
{
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;
    using CrowdSourcedNews.Services.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http.Dependencies;

    public class DbDependencyResolver : IDependencyResolver
    {
        private DbContext context;
        private IRepository<NewsArticle> newsArticlesRepository;
        private IRepository<Comment> commentsRepository;
        private DbUsersRepository usersRepository;

        public DbDependencyResolver(DbContext context)
        {
            this.context = context;
            this.newsArticlesRepository = new DbRepository<NewsArticle>(context);
            this.commentsRepository = new DbRepository<Comment>(context);
            this.usersRepository = new DbUsersRepository(context);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(usersRepository);
            }
            else if (serviceType == typeof(NewsArticlesController))
            {
                return new NewsArticlesController(
                    newsArticlesRepository, usersRepository, commentsRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose() { }
    }
}