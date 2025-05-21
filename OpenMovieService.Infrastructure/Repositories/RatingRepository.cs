using OpenMovieService.Domain.Model;
using OpenMovieService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public Task<ServiceResponse<Rating>> AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Rating>> DeleteRating(string ratingId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Rating>> GetRatingById(string ratingId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Rating>> UpdateRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
