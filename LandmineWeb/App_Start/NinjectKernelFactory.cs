using Landmine.Domain.Abstract;
using Landmine.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmineWeb.App_Start
{
    public static class NinjectKernelFactory
    {
        private static Lazy<IKernel> kernel;
        public static IKernel Kernel { get { return kernel.Value; } }

        static NinjectKernelFactory()
        {
            kernel = new Lazy<IKernel>(() =>
            {
                var k = new StandardKernel();
                bind(k);
                return k;
            });
        }

        private static void bind(IKernel ninject)
        {
            ninject.Bind<IScoreRepository>().To<ScoreRepository>();
        }
    }
}