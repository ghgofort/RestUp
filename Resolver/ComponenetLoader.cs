using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Resolver
{
    /// <summary>
    /// Class for loading the dependencies using the Unity DI container
    /// </summary>
    public static class ComponenetLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var cat = new DirectoryCatalog(path, pattern);
            var def = BuildImportDefinition();
            try
            {
                using (var aggCat = new AggregateCatalog())
                {
                    aggCat.Catalogs.Add(cat);
                    using (var compositionContainer = new CompositionContainer(aggCat))
                    {
                        IEnumerable<Export> exports = compositionContainer.GetExports(def);
                        IEnumerable<IComponent> modules = exports.Select(x => x.Value as IComponent).Where(m => m != null);
                        var regComponenet = new RegisterComponent(container);
                        foreach (IComponent module in modules)
                        {
                            module.SetUp(regComponenet);
                        }
                    }
                }
            }
            catch(ReflectionTypeLoadException tlException)
            {
                var build = new StringBuilder();
                foreach(Exception ex in tlException.LoaderExceptions)
                {
                    build.AppendFormat("{0}\n", ex.Message);
                }
                throw new TypeLoadException(build.ToString(), tlException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(d => true, typeof(IComponent).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    /// <summary>
    /// Internal class for registering each component using the IRegisterComponent interface with the Unity DI container
    /// </summary>
    internal class RegisterComponent : IRegisterComponent
    {
        private IUnityContainer _container;

        public RegisterComponent(IUnityContainer container)
        {
            this._container = container;
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if(withInterception)
            {
                // This is where we would register any modules that need to loaded with interception
            }
            else
            {
                this._container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            throw new NotImplementedException();
        }
    }
}
