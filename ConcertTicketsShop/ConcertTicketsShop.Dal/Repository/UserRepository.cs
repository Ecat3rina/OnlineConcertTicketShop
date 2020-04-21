using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConcertTicketsShopDbContext _context;
        public UserRepository(ConcertTicketsShopDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
