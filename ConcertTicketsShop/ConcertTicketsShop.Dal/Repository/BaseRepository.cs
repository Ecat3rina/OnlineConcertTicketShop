using System.Collections.Generic;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketsShop.Dal.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ConcertTicketsShopDbContext _context;
        public BaseRepository(ConcertTicketsShopDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
