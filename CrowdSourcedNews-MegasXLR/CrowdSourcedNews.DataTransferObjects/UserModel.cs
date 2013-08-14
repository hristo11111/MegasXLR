namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserModel
    {
        private ICollection<NewsArticleModel> newsArticles;

        private ICollection<CommentDetails> comments;

        public UserModel()
        {
            this.newsArticles = new HashSet<NewsArticleModel>();
            this.comments = new HashSet<CommentDetails>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "newsArticles")]
        public ICollection<NewsArticleModel> NewsArticles
        {
            get { return this.newsArticles; }

            set { this.newsArticles = value; }
        }

        [DataMember(Name = "comments")]
        public ICollection<CommentDetails> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }
    }
}