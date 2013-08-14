namespace CrowdSourcedNews.Mappers
{
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    public static class NewsArticlesMapper
    {
        public static NewsArticle ToNewsArticleEntity(
            NewsArticleModel newsArticleModel,
            DbUsersRepository usersRepository,
            IRepository<Comment> commentsRepository)
        {
            NewsArticle newsArticleEntity = new NewsArticle()
                {
                    ID = newsArticleModel.ID,
                    Author = usersRepository.GetByNickname(newsArticleModel.Author),
                    Content = newsArticleModel.Content,
                    Date = newsArticleModel.Date,
                    ImagesUrls = newsArticleModel.ImagesUrls,
                    Rating = newsArticleModel.Rating,
                    Title = newsArticleModel.Title
                };

            foreach (CommentModel comment in newsArticleModel.Comments)
            {
                newsArticleEntity.Comments.Add(
                    Extensions.CreateOrLoadComment(comment, commentsRepository, usersRepository));
            }

            return newsArticleEntity;
        }

        public static NewsArticleModel ToNewsArticleModel(NewsArticle newsArticle)
        {
            NewsArticleModel newsArticleModel = new NewsArticleModel()
                {
                    ID = newsArticle.ID,
                    Title = newsArticle.Title,
                    Content = newsArticle.Content,
                    Rating = newsArticle.Rating,
                    ImagesUrls = newsArticle.ImagesUrls,
                    Date = newsArticle.Date,
                    Author = newsArticle.Author.Nickname
                };

            foreach (Comment comment in newsArticle.Comments)
            {
                newsArticleModel.Comments.Add(CommentsMapper.ToCommentModel(comment));
            }

            return newsArticleModel;
        }
    }
}
