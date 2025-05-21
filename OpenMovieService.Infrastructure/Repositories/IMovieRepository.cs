using OpenMovieService.Domain.Model;
using OpenMovieService.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Repositories
{
    public interface IMovieRepository
    {
        Task<ServiceResponse<Movie>> AddMovie(Movie movie);
        Task<ServiceResponse<Movie>> UpdateMovie(Movie movie);
        Task<ServiceResponse<Movie>> DeleteMovie(string movieId);
        Task<ServiceResponse<Movie>> GetMovieById(string movieId);
        Task<ServiceResponse<Movie>> GetMovieByTitle(string name);
    }
}
