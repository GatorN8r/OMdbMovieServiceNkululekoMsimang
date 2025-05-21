using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

        public async Task<string> BuildUrl(string baseUrl, string endpoint, Dictionary<string, string> parameters)
        {
            var queryString = GetQueryString(parameters);
            return await Task.FromResult($"{GetBaseUrl(baseUrl, endpoint)}?{queryString}");
        }

        public async Task<string> GetBaseUrl(string baseUrl, string endpoint)
        {
            return await Task.FromResult($"{baseUrl}/{endpoint}");
        }

        public async Task<string> GetQueryString(Dictionary<string, string> parameters)
        {
            return await Task.FromResult(string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}")));
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            return await _httpClient.PostAsJsonAsync(url, data);
        }
        public async Task<T> GetFromJsonAsync<T>(string url)
        {
            return await _httpClient.GetFromJsonAsync<T>(url);  
        }
    }
}
