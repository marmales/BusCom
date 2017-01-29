using Domain.Abstract;
using Domain.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCom.Infrastructure
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependecyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
            kernel.Bind<IChatRepository>().To<ChatRepository>();
            kernel.Bind<IRepoRepository>().To<RepoRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}