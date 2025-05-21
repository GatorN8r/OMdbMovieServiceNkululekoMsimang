using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.DatabaseEntities;
using OpenMovieService.Infrastructure.Mappers.Ratings;

namespace OpenMovieService.Infrastructure.Mappers.Movies
{
    public class MoviesMapper: IMovieMapper
    {

        private readonly IRatingMapper _ratingMapper;

        public MoviesMapper(IRatingMapper ratingMapper)
        {
            _ratingMapper = ratingMapper ?? throw new ArgumentNullException(nameof(ratingMapper));
        }

        public async Task<MovieEntity> MapToEntity(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null");
            }

            var ratingEntity = await _ratingMapper.MapToEntity(movie.Ratings, new Guid());

            return await Task.FromResult(new MovieEntity
            {
                Id = new Guid(),
                Title = movie.Title,
                Year = movie.Year,
                Rated = movie.Rated,
                Released = movie.Released,
                Runtime = movie.Runtime,
                Genre = movie.Genre,
                Director = movie.Director,
                Writer = movie.Writer,
                Actors = movie.Actors,
                Plot = movie.Plot,
                Language = movie.Language,
                Country = movie.Country,
                Awards = movie.Awards,
                Poster = movie.Poster,
                Metascore = movie.Metascore,
                imdbRating = movie.imdbRating,
                imdbVotes = movie.imdbVotes,
                imdbID = movie.imdbID,
                Type = movie.Type,
                DVD = movie.DVD,
                BoxOffice = movie.BoxOffice,
                Production = movie.Production,
                Website = movie.Website,
                Response = movie.Response,
                Ratings = ratingEntity
            });
        }

        public async Task<Movie> MapToDomain(MovieEntity movieEntity)
        {
            if (movieEntity == null)
            {
                throw new ArgumentNullException(nameof(movieEntity), "MovieEntity cannot be null");
            }
            var rating = await _ratingMapper.MapToDomain(movieEntity.Ratings);
            return await Task.FromResult(new Movie
            {
                Title = movieEntity.Title,
                Year = movieEntity.Year,
                Rated = movieEntity.Rated,
                Released = movieEntity.Released,
                Runtime = movieEntity.Runtime,
                Genre = movieEntity.Genre,
                Director = movieEntity.Director,
                Writer = movieEntity.Writer,
                Actors = movieEntity.Actors,
                Plot = movieEntity.Plot,
                Language = movieEntity.Language,
                Country = movieEntity.Country,
                Awards = movieEntity.Awards,
                Poster = movieEntity.Poster,
                Ratings = rating,
                Metascore = movieEntity.Metascore,
                imdbRating = movieEntity.imdbRating,
                imdbVotes = movieEntity.imdbVotes,
                imdbID = movieEntity.imdbID,
                Type = movieEntity.Type,
                DVD = movieEntity.DVD,
                BoxOffice = movieEntity.BoxOffice,
                Production = movieEntity.Production,
                Website = movieEntity.Website,
                Response = movieEntity.Response
            });
        }
    }
}
