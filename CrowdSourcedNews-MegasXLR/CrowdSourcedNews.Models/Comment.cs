namespace CrowdSourcedNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        private ICollection<Comment> comments;

        public Comment()
        {
            this.comments = new List<Comment>();
        }

        [Key]
        public int ID { get; set; }

        public int AuthorID { get; set; }

        [Required, ForeignKey("AuthorID")]
        public User Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool IsNested { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }
    }
}
