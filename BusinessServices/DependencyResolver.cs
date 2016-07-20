using DataEntities;
using DataEntities.UnitOfWork;
using Resolver;
using System.ComponentModel.Composition;
using System;

namespace BusinessServices
{
    /// <summary>
    /// Class implementation for resolving the dependencies between DAL entities, and Business Entities
    /// </summary>
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        /// <summary>
        /// Register the component to the DI contianer
        /// </summary>
        /// <param name="registerComponent"></param>
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IBasketServices, BasketServices>();
        }
    }
}
