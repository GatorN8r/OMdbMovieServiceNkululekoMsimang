using OpenMovieService.Domain.Model;
using OpenMovieService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Task<ServiceResponse<Movie>> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Movie>> DeleteMovie(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Movie>> GetMovieById(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Movie>> GetMovieByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Movie>> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
