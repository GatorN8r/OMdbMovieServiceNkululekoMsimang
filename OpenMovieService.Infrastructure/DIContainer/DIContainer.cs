using SimpleInjector;
using OpenMovieService.Infrastructure.Services;
using OpenMovieService.Infrastructure.Helpers;
using System.Net.Http;

namespace OpenMovieService.Infrastructure.DIContainer
{
    public static class DIContainer
    {
        public static void RegisterServices(Container container)
        {
            // Register your services here
            container.Register<IOMDbService, OMDbService>(Lifestyle.Scoped);
            container.Register<IHttpHelper, HttpHelper>(Lifestyle.Scoped);
        }
    }
}
