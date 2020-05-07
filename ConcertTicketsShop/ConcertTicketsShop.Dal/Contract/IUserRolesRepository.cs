using System.Collections.Generic;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Entities;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IUserRolesRepository : IBaseRepository<UserRole>
    {
        public Task<IList<UserRole>> GetUserRoles(int userId);
    }
}
