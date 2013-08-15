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
            this.ImagesUrls = new HashSet<string>();
            this.Comments = new HashSet<CommentModel>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        [DataMember(Name = "images")]
        public ICollection<string> ImagesUrls { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentModel> Comments { get; set; }
    }
}
