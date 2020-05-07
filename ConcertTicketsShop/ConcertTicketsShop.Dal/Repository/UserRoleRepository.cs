using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketsShop.Dal.Repository
{
    public class UserRoleRepository : BaseRepository<UserRole> , IUserRolesRepository
    {
        public UserRoleRepository(ConcertTicketsShopDbContext context) : base(context)
        {
        }

        public async Task<IList<UserRole>> GetUserRoles(int userId)
        {
            return await _context.UserRoles.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
