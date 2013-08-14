namespace CrowdSourcedNews.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class NewsArticleModel
    {
        public NewsArticleModel()
        {
            this.Images = new HashSet<string>();
            this.Comments = new HashSet<CommentDetails>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "author")]
        public UserModel Author { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        [DataMember(Name = "images")]
        public ICollection<string> Images { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentDetails> Comments { get; set; }
    }
}
