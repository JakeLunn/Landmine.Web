using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Ninject;

namespace LandmineWeb.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninject;

        public NinjectControllerFactory()
        {
            ninject = NinjectKernelFactory.Kernel;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninject.Get(controllerType);
        }
    }
}