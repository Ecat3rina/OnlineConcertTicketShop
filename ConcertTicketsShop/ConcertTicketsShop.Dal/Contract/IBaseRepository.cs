using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        void Update(TEntity entity);
    }
}
