using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IWishlistRepository _wishlistRepository;
        public ConcertService(IConcertRepository concertRepository, IVenueRepository venueRepository, IWishlistRepository wishlistRepository)
        {
            _concertRepository = concertRepository;
            _venueRepository = venueRepository;
            _wishlistRepository = wishlistRepository;
        }


        public async Task<IList<ConcertDescriptionResponseModel>> GetTrendingConcerts(int userId)
        {
            var concerts = await _concertRepository.GetAll();
            var venues = (await _venueRepository.GetAll()).ToDictionary(x => x.Id);
            var myWishlist = (await _wishlistRepository.GetUserWhishlistAsync(userId)).ToDictionary(x => x.ConcertId);

            return concerts.Select(x => new ConcertDescriptionResponseModel
            {
                Date = x.ConcertDate,
                Duration = "TBD",
                Id = x.Id,
                Name = x.Name,
                VenueName = venues[x.Id].VenueName,
                AddedToWishlist = myWishlist.ContainsKey(x.Id)
            }).ToList();
        }

        public async Task<IList<ConcertDescriptionResponseModel>> GetConcertsFromWhishlistAsync(int userId)
        {
            var userWhishlist =  await _wishlistRepository.GetUserWhishlistAsync(userId);
            var allConcerts = (await _concertRepository.GetAll()).ToDictionary(x => x.Id);
            var venues = (await _venueRepository.GetAll()).ToDictionary(x => x.Id);
            var wishlist = new List<ConcertDescriptionResponseModel>();

            foreach (var concert in userWhishlist)
            {
                var concertModel = allConcerts[concert.ConcertId];

                wishlist.Add(new ConcertDescriptionResponseModel
                {
                    Name = concertModel.Name,
                    Duration = "TBD",
                    Id = concertModel.Id,
                    Date = concertModel.ConcertDate,
                    VenueName = venues[concertModel.VenueId].VenueName
                });
            }
            return wishlist;
        }
    }
}
