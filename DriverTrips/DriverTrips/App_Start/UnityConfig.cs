using DriverTrips.TripManager;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace DriverTrips
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ITripManager, TripManager.TripManager>(new HierarchicalLifetimeManager());
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}