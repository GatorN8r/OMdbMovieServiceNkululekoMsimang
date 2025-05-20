using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.Helpers
{
    public interface IHttpHelper
    {
        Task<string> GetBaseUrl(string baseUrl, string endpoint);
        Task<string> GetQueryString(Dictionary<string, string> parameters);
        Task<string> BuildUrl(string baseUrl, string endpoint, Dictionary<string, string> parameters);
    }
}
