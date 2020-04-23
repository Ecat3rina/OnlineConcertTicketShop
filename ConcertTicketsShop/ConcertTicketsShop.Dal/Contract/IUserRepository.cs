using ConcertTicketsShop.Dal.Entities;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
