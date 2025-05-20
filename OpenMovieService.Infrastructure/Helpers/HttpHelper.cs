using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        private readonly HttpClient _httpClient;
        public HttpHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> BuildUrl(string baseUrl, string endpoint, Dictionary<string, string> parameters)
        {
            var queryString = GetQueryString(parameters);
            return Task.FromResult($"{GetBaseUrl(baseUrl, endpoint)}?{queryString}");
        }

        public Task<string> GetBaseUrl(string baseUrl, string endpoint)
        {
            return Task.FromResult($"{baseUrl}/{endpoint}");
        }

        public Task<string> GetQueryString(Dictionary<string, string> parameters)
        {
            return Task.FromResult(string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}")));
        }


    }
}
