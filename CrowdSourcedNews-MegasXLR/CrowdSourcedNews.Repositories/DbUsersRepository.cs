namespace CrowdSourcedNews.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using CrowdSourcedNews.Models;

    public class DbUsersRepository : DbRepository<User>
    {
        public DbUsersRepository(DbContext context)
            : base(context)
        { }

        public User GetByNickname(string nickname)
        {
            return this.GetAll().First<User>(u => u.Nickname == nickname);
        }
    }
}
