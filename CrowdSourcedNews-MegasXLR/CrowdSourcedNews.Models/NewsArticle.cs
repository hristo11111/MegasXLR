﻿namespace CrowdSourcedNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NewsArticle
    {
        private ICollection<Comment> comments;

        public NewsArticle()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key, Column("NewsArticleID")]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int Rating { get; set; }

        public ICollection<byte[]> Images { get; set; }

        public int AuthorID { get; set; }

        [Required, ForeignKey("AuthorID")]
        public User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }
    }
}