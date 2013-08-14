namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentModel : CommentDetails
    {
        private ICollection<CommentDetails> comments;

        public CommentModel()
        {
            this.comments = new List<CommentDetails>();
        }

        [DataMember(Name = "comments")]
        public ICollection<CommentDetails> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }
    }
}
