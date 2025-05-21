using SimpleInjector;
using OpenMovieService.Infrastructure.Services;
using OpenMovieService.Infrastructure.Helpers;
using System.Net.Http;
using OpenMovieService.Infrastructure.Mappers.Movies;
using OpenMovieService.Infrastructure.Repositories;
using OpenMovieService.Infrastructure.Mappers.Ratings;

namespace OpenMovieService.Infrastructure.DIContainer
{
    public static class DIContainer
    {
        public static void RegisterServices(Container container)
        {
            // Register your services here
            container.Register<IOMDbService, OMDbService>(Lifestyle.Scoped);
            container.Register<IHttpHelper, HttpHelper>(Lifestyle.Scoped);
            container.Register<IMovieMapper, MoviesMapper>(Lifestyle.Scoped);
            container.Register<IMovieRepository, MovieRepository>(Lifestyle.Scoped);
            container.Register<IRatingMapper, RatingMapper>(Lifestyle.Scoped);
            container.Register<IRatingRepository, RatingRepository>(Lifestyle.Scoped);

        }
    }
}
