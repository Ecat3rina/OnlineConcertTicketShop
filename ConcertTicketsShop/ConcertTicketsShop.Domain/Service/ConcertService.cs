using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Response;

namespace ConcertTicketsShop.Domain.Service
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IVenueRepository _venueRepository;
        public ConcertService(IConcertRepository concertRepository, IVenueRepository venueRepository)
        {
            _concertRepository = concertRepository;
            _venueRepository = venueRepository;
        }


        public async Task<IList<ConcertDescriptionResponseModel>> GetTrendingConcerts()
        {
            var concerts = await _concertRepository.GetAll();
            var venues = (await _venueRepository.GetAll()).ToDictionary(x => x.Id);

            return concerts.Select(x => new ConcertDescriptionResponseModel
            {
                Date = x.ConcertDate,
                Duration = "TBD",
                Id = x.Id,
                Name = x.Name,
                VenueName = venues[x.Id].VenueName
            }).ToList();
        }
    }
}
