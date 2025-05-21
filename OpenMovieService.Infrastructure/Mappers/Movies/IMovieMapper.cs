using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.DatabaseEntities;

namespace OpenMovieService.Infrastructure.Mappers.Movies
{
    public interface IMovieMapper
    {
        Task<MovieEntity> MapToEntity(Movie movie);
        Task<Movie> MapToDomain(MovieEntity movieEntity);
    }
}
