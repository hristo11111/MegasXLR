namespace CrowdSourcedNews.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key, Column("UserID")]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string SessionKey { get; set; }
    }
}
