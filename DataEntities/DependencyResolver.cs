using DataEntities.UnitOfWork;
using Resolver;
using System.ComponentModel.Composition;

namespace DataEntities
{
    /// <summary>
    /// Used to resolve dependiencies between layers for the UnitOfWork type
    /// NOTE: this class uses our own implementation of IComponent found in the Resolver namespace
    /// This is not the same as System.IComponent
    /// </summary>
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        /// <summary>
        /// Sets up the dependency between the DAL and the Business Service that both use UnitOfWork
        /// as a DTO (Data Transfer Object)
        /// </summary>
        /// <param name="registerComponent"></param>
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
