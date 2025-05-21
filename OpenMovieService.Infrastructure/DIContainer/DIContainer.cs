using SimpleInjector;
using OpenMovieService.Infrastructure.Services;
using OpenMovieService.Infrastructure.Helpers;
namespace OpenMovieService.Infrastructure.DIContainer
{
    public static class DIContainer
    {
        public readonly static Container _container;

        static DIContainer()
        {
            _container = new Container();
            RegisterServices(_container);
        }

        private static void RegisterServices(Container container)
        {
            // Register your services here
             container.Register<IOMDbService, OMDbService>(Lifestyle.Scoped);
             container.Register<IHttpHelper, HttpHelper>(Lifestyle.Scoped);

            container.Verify(); // Verify the container configuration
        }
    }
}
