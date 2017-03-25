[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BulgarianCreators.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BulgarianCreators.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BulgarianCreators.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Factory;
    using Ninject.Extensions.Conventions;
    using Data;
    using BulgarianCreators.Models.Factories;
    using Mapping;
    using Data.Services.Contracts;
    using Data.Services;
    using NinjectModules;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(ICreatorsDbContext), typeof(ICreatorsDbSaveChangesContext))
                .To<CreatorsDbContext>().InRequestScope();

            //kernel.Bind(typeof(ICreatorsDbSaveChangesContext))
            //    .To<CreatorsDbContext>().InRequestScope();

            kernel.Load(new AutoMapperModule());

            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IUserService>().To<UserService>();

            kernel.Bind(r => r
                .FromAssemblyContaining<IPostFactory>()
                .SelectAllClasses()
                .BindAllInterfaces());

            kernel.Bind(
                r => r.FromAssemblyContaining<IPostFactory>()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory());

        }
    }
}
