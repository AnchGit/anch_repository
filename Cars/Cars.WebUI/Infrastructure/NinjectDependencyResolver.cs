﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Ninject;
using Moq;
using Cars.Domain.Abstract;
using Cars.Domain.Concrete;
using Cars.Domain.Entities;

namespace Cars.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICarRepository>().To<EFDbCarRepository>();
            kernel.Bind<IMarkRepository>().To<EFDBMarkRepository>();
        }
    }
}