using System;
using System.Collections.Generic;
using System.Linq;

using Landmine.Domain.Abstract;
using Landmine.Domain.Concrete;

using Ninject;

namespace LandmineWeb.App_Start
{
    public static class NinjectKernelFactory
    {
        private static readonly Lazy<IKernel> _kernel;

        public static IKernel Kernel { get; } = _kernel.Value;

        static NinjectKernelFactory()
        {
            _kernel = new Lazy<IKernel>(() =>
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