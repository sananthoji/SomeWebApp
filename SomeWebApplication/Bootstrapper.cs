using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using System.Configuration;
using System.IO;
using System;
using System.Web;
using DataAccessLayer.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.ServiceLocation;
using SomeWebApplication.Factories;

namespace SomeWebApplication
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            
            UnityMvcServiceLocator unityMVCServiceLocator = new UnityMvcServiceLocator(container);
            var factory = new ServiceLocatorControllerFactory(unityMVCServiceLocator);
            ControllerBuilder.Current.SetControllerFactory(factory);
            DependencyResolver.SetResolver(unityMVCServiceLocator);
            //ModelBinders.Binders.DefaultBinder = new InterfaceModelBinder(unityMVCServiceLocator);
            //HttpContext.Current.Cache["UnityServiceLocator"] = unityMVCServiceLocator;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();   

            var unitySection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            container.LoadConfiguration(unitySection, "SomeUnityContainer");
            //container.RegisterType<IDataAccessLayer, DataAccessLayer.Processors.DataAccessLayers>(new HierarchicalLifetimeManager());
            return container;
        }
    }
    
}