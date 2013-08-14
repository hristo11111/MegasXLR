﻿namespace CrowdSourcedNews.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<NewsArticle> newsArticles;
        private ICollection<Comment> comments;

        public User()
        {
            this.newsArticles = new HashSet<NewsArticle>();
            this.comments = new HashSet<Comment>();
        }

        [Key, Column("UserID")]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles
        {
            get { return this.newsArticles; }

            set { this.newsArticles = value; }
        }
    }
}
