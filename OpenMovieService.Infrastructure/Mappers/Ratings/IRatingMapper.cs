using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.DatabaseEntities;

namespace OpenMovieService.Infrastructure.Mappers.Ratings
{
    public interface IRatingMapper
    {
        Task<List<RatingEntity>> MapToEntity(List<Rating> ratings, Guid movieId);
        Task<List<Rating>> MapToDomain(List<RatingEntity> ratingEntities);
    }
}
