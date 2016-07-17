using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Resolver;

namespace RestUp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        /// <summary>
        /// Utilize Microsoft Extensibility Framework (MEF) to initialize our components
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterTypes(UnityContainer container)
        {
            ComponenetLoader.LoadContainer(container, ".\\bin", "WebApi.dll");
            ComponenetLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");
        }
    }
}