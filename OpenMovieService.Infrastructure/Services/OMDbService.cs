using Microsoft.Extensions.Configuration;
using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Services
{
    public class OMDbService : IOMDbService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IConfiguration _configuration;

        public OMDbService(IHttpHelper httpHelper, IConfiguration configuration)
        {
         _httpHelper = httpHelper;
         _configuration = configuration;
        }

        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByTitle(string name)
        {
            string DIHttp = await DIContainer.DIContainer._container.GetInstance<IHttpHelper>().GetBaseUrl(_configuration["AppSettings:OMDbBaseUrl"], $"t= {name}&apikey={_configuration["AppSettings:OMDbMovieKey"]}");
            var url = await DIHttp.
            var response = await _httpClient.GetAsync(url);
        }

    }
}
