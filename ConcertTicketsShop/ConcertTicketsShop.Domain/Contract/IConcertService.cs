using System.Collections.Generic;
using System.Threading.Tasks;
using ConcertTicketsShop.Domain.Response;

namespace ConcertTicketsShop.Domain.Contract
{
    public interface IConcertService
    {
        Task<IList<ConcertDescriptionResponseModel>> GetTrendingConcerts();
    }
}
