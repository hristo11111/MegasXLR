namespace CrowdSourcedNews.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentDetails
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "author")]
        public UserModel Author { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "isNested")]
        public bool IsNested { get; set; }
    }
}
