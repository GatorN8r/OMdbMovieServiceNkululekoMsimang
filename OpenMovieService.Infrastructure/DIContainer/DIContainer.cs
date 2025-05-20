using SimpleInjector;
using OpenMovieService.Infrastructure.Services;

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
             container.Register<IOMDbService, OMDbService>();

            container.Verify(); // Verify the container configuration
        }
    }
}
