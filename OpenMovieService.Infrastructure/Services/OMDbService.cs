using Microsoft.Extensions.Configuration;
using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public async Task<Movie> GetMovieById(string id)
        {
            var url = await DIContainer.DIContainer._container.GetInstance<IHttpHelper>().GetBaseUrl(_configuration["AppSettings:OMDbBaseUrl"], $"i={id}&apikey={_configuration["AppSettings:OMDbMovieKey"]}");
            var response = await _httpHelper.GetFromJsonAsync<Movie>(url);

            if (response != null && response.Response == "True")
            {
                return response;
            }
            else
            {
                throw new NullReferenceException("Movie not found");
            }
        }

        public async Task<Movie> GetMovieByTitle(string name)
        {
            var url = await DIContainer.DIContainer._container.GetInstance<IHttpHelper>().GetBaseUrl(_configuration["AppSettings:OMDbBaseUrl"], $"t={name}&apikey={_configuration["AppSettings:OMDbMovieKey"]}");
            var response =  await _httpHelper.GetFromJsonAsync<Movie>(url);
            
            if (response != null && response.Response == "True")
            {
                return response;
            }
            else
            {
                throw new NullReferenceException("Movie not found");
            }
        }
    }
}
