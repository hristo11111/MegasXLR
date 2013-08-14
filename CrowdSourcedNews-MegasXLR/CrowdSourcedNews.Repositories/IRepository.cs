using System.Linq;

namespace CrowdSourcedNews.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        T Add(T item);

        T Delete(int id);

        bool Update(int id, T item);
    }
}
