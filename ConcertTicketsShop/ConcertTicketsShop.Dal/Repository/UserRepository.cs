using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {   
        public UserRepository(ConcertTicketsShopDbContext context) : base(context)
        {
            
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
