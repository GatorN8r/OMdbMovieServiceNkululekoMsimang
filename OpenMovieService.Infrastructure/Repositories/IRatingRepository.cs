using System;
using System.Collections.Generic;
using System.Linq;
using OpenMovieService.Domain.Model;
using OpenMovieService.Shared;

namespace OpenMovieService.Infrastructure.Repositories
{
    public interface IRatingRepository
    {
        Task<ServiceResponse<List<Rating>>> AddRating(List<Rating> rating);
        Task<ServiceResponse<Rating>> UpdateRating(Rating rating);
        Task<ServiceResponse<Rating>> DeleteRating(string ratingId);
        Task<ServiceResponse<Rating>> GetRatingById(string ratingId);
    }
}
