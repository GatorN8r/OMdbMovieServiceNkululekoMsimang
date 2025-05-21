using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.Data;
using OpenMovieService.Infrastructure.Mappers.Ratings;
using OpenMovieService.Shared;

namespace OpenMovieService.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _context;
        private readonly IRatingMapper _ratingMapper;
        public RatingRepository(DataContext context, IRatingMapper ratingMapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _ratingMapper = ratingMapper ?? throw new ArgumentNullException(nameof(ratingMapper));
        }
        public async Task<ServiceResponse<List<Rating>>> AddRating(List<Rating> rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException();
            }

            var ratingEntity = _ratingMapper.MapToEntity(rating, new Guid()).Result;

            if (ratingEntity == null || ratingEntity.Count == 0)
            {
                throw new ArgumentNullException(nameof(ratingEntity), "Rating cannot be null");
            }

            foreach (var ratingItem in ratingEntity)
            {
                _context.Ratings.Add(ratingItem);
            }

            var result = _context.SaveChanges();

            if (result > 0)
            {
                return await Task.FromResult(new ServiceResponse<List<Rating>>
                {
                    Success = true,
                    Data = rating,
                    Message = "Rating added successfully"
                });

            }
            else
            {
                return await Task.FromResult(new ServiceResponse<List<Rating>>
                {
                    Success = false,
                    Message = "Failed to add rating to database"
                });
            }


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
