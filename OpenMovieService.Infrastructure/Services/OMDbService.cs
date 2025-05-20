using OpenMovieService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Services
{
    public class OMDbService : IOMDbService
    {
        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public void PopulateRequestHeader()
        {
            throw new NotImplementedException();
        }
    }
}
