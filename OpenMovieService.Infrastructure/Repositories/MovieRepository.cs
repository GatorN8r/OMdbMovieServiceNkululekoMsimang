using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.Data;
using OpenMovieService.Infrastructure.Mappers.Movies;
using OpenMovieService.Shared;

namespace OpenMovieService.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        private readonly IMovieMapper _movieMapper;
        public MovieRepository(DataContext context, IMovieMapper movieMapper)
        {
            _context = context;
            _movieMapper = movieMapper;
        }

        public Task<ServiceResponse<Movie>> AddMovie(Movie movie)
        {
            if (movie == null)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie cannot be null"
                });
            }

            var movieEntity = _movieMapper.MapToEntity(movie).Result;
            _context.Movies.Add(movieEntity);
            var result = _context.SaveChanges();

            if (result > 0)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = true,
                    Data = movie,
                    Message = "Movie added successfully"
                });
            }
            else
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Failed to add movie to database"
                });
            }
        }

        public Task<ServiceResponse<Movie>> DeleteMovie(string movieId)
        {
            if (movieId == null)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie ID cannot be null"
                });
            }

            var movieEntity = _context.Movies.Find(movieId);
            if (movieEntity == null)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie not found"
                });
            }

            _context.Movies.Remove(movieEntity);
            var result = _context.SaveChanges();

            if (result > 0)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = true,
                    Message = "Movie deleted successfully"
                });
            }
            else
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Failed to delete movie from database"
                });
            }

         }

        public async Task<ServiceResponse<Movie>> GetMovieById(string movieId)
        {
            if (movieId == null)
            {
                return await Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie ID cannot be null"
                });
            }

            var movieEntity = _context.Movies.Find(movieId);
            if (movieEntity == null)
            {
                return await Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie not found"
                });
            }
            else { 
            
                return await Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = true,
                    Data = await _movieMapper.MapToDomain(movieEntity),
                    Message = "Movie retrieved successfully"
                });

            }
        }

        public Task<ServiceResponse<Movie>> GetMovieByTitle(string name)
        {
            if (name == null)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie name cannot be null"
                });
            }

            var movieEntity = _context.Movies.FirstOrDefault(m => m.Title == name);

            if (movieEntity == null)
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie not found"
                });
            }
            else
            {
                return Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = true,
                    Data = _movieMapper.MapToDomain(movieEntity).Result,
                    Message = "Movie retrieved successfully"
                });
            }
        }

        public async Task<ServiceResponse<Movie>> UpdateMovie(Movie movie)
        {

            if (movie  == null)
            {
                return await Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie cannot be null"
                });
            }

            var movieEntity = _context.Movies.Find(movie.imdbID);

            if (movieEntity == null)
            {
                return await Task.FromResult(new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie not found"
                });
            }

                    movieEntity.Title = movie.Title;
                    movieEntity.Year = movie.Year;
                    movieEntity.Rated = movie.Rated;
                    movieEntity.Released = movie.Released;
                    movieEntity.Runtime = movie.Runtime;
                    movieEntity.Genre = movie.Genre;
                    movieEntity.Director = movie.Director;
                    movieEntity.Writer = movie.Writer;
                    movieEntity.Actors = movie.Actors;
                    movieEntity.Plot = movie.Plot;
                    movieEntity.Language = movie.Language;
                    movieEntity.Country = movie.Country;
                    movieEntity.Awards = movie.Awards;
                    movieEntity.Poster = movie.Poster;
                    movieEntity.Metascore = movie.Metascore;
                    movieEntity.imdbRating = movie.imdbRating;
                    movieEntity.imdbVotes = movie.imdbVotes;
                    movieEntity.Type = movie.Type; 
                    movieEntity.DVD = movie.DVD;
                    movieEntity.BoxOffice = movie.BoxOffice;
                    movieEntity.Production = movie.Production;
                    movieEntity.Website = movie.Website;
                    movieEntity.Response = movie.Response;
    
                    var result = _context.SaveChanges();

                if (result > 0)
                {
                    return await Task.FromResult(new ServiceResponse<Movie>
                    {
                        Success = true,
                        Data = await _movieMapper.MapToDomain(movieEntity),
                        Message = "Movie updated successfully"
                    });
                }
                else
                {
                    return await Task.FromResult(new ServiceResponse<Movie>
                    {
                        Success = false,
                        Message = "Failed to update the Movie in the database"
                    });
                }

        }
    }
}
