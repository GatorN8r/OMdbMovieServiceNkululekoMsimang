using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.DatabaseEntities;

namespace OpenMovieService.Infrastructure.Mappers.Ratings
{
    public class RatingMapper
    {
        public async Task<List<RatingEntity>> MapToEntity(List<Rating> ratings, Guid movieId)
        {
            if (ratings.Count == 0)
            {
                throw new ArgumentNullException(nameof(ratings), "Rating cannot be null");
            }

            var entity = new List<RatingEntity>();

            foreach (var rating in ratings) {
                entity.Add(new RatingEntity
                {
                    Id = new Guid(),
                    Source = rating.Source,
                    Value = rating.Value,
                    MovieId = movieId
                });
            }

            return await Task.FromResult(entity);
        }

        public async Task<List<Rating>> MapToDomain(List<RatingEntity> ratingEntities)
        {
            if (ratingEntities.Count == 0)
            {
                throw new ArgumentNullException(nameof(ratingEntities), "RatingEntity cannot be null");
            }
            var ratings = new List<Rating>();
            foreach (var ratingEntity in ratingEntities) {
                ratings.Add(new Rating
                {
                    Source = ratingEntity.Source,
                    Value = ratingEntity.Value
                });
            }
            return await Task.FromResult(ratings);
        }
    }
}
