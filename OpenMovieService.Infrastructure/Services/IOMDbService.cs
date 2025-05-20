using OpenMovieService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Services
{
    public interface IOMDbService
    {
        void PopulateRequestHeader();
        Task<Movie> GetMovieById(string id);
        Task<Movie> GetMovieByTitle(string name);
    }
}
