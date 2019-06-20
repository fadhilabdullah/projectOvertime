using BusinessLogic.Service;
using BusinessLogic.Service.Application;
using Common.Repository;
using Common.Repository.Application;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //this is for Repository 
            container.RegisterType<IDataOvertimeRepository, DataOvertimeRepository>();
            container.RegisterType<ISubmitedRepository, SubmitedRepository>();

            //this is for Service
            container.RegisterType<IDataOvertimeService, DataOvertimeService>();
            container.RegisterType<ISubmitedService, SubmitedService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}