using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        void Update(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task Create(TEntity entity);
        void Delete(TEntity entity);
    }
}
