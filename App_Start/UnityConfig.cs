using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using StackOverflowProject.ServiceLayer;
using System.Web.Mvc;

namespace StackOverflowProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IQuestionsService,QuestionsService>();

            // register all your components with the container here
            // it is NOT necessary to register your cotrollers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}