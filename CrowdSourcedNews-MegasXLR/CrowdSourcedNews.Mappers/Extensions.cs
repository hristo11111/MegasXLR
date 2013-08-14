namespace CrowdSourcedNews.Mappers
{
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    internal static class Extensions
    {
        public static Comment CreateOrLoadComment(
            CommentModel comment,
            DbUsersRepository usersRepository,
            IRepository<Comment> commentRepository)
        {
            Comment commentEntity = commentRepository.Get(comment.ID);
            if (commentEntity != null)
            {
                return commentEntity;
            }

            Comment newComment = CommentsMapper.ToCommentEntity(comment, usersRepository);

            return newComment;
        }
    }
}
