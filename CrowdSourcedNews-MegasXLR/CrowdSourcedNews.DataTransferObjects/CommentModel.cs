namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentModel : CommentDetails
    {
        public CommentModel()
        {
            this.Comments = new List<CommentDetails>();
        }

        [DataMember(Name = "comments")]
        public ICollection<CommentDetails> Comments { get; set; }
    }
}
