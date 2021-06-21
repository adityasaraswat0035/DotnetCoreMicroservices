using mango.infrastructure.boilerplate.contracts;
using mango.infrastructure.boilerplate.managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate
{
    /// <summary>
    /// This class to bootstrap the application
    /// </summary>
    public class Bootstraper
    {
        private Dictionary<Type, IApplicationManager> applicationManagers;

        public Bootstraper(IConfiguration configuration)
        {
            applicationManagers = new Dictionary<Type, IApplicationManager>();
            applicationManagers.Add(typeof(DefaultGlobalExceptionManager), new DefaultGlobalExceptionManager());
            applicationManagers.Add(typeof(DefaultSwaggerManager), new DefaultSwaggerManager());
            applicationManagers.Add(typeof(DefaultAutoMapperManager), new DefaultAutoMapperManager());
            applicationManagers.Add(typeof(DefaultMessageBrokerManager), new DefaultMessageBrokerManager());
            applicationManagers.Add(typeof(DefaultAuthenticationManager), new DefaultAuthenticationManager());
            applicationManagers.Add(typeof(DefaultAuthorizationManager), new DefaultAuthorizationManager());
            applicationManagers.Add(typeof(DefaultDbContextManager), new DefaultDbContextManager() { Configuration = configuration });
            applicationManagers.Add(typeof(DefaultDatabaseSeedManager), new DefaultDatabaseSeedManager());
            applicationManagers.Add(typeof(DefaultApplicationServicesManager), new DefaultApplicationServicesManager());
            applicationManagers.Add(typeof(DefaultControllerRoutingManager), new DefaultControllerRoutingManager());

            CheckAndReplaceIfAnyManagerExtended(configuration);
        }

        private void CheckAndReplaceIfAnyManagerExtended(IConfiguration configuration)
        {
            Assembly mainExecutionAssembly = Assembly.GetEntryAssembly();
            mainExecutionAssembly.GetTypes().ToList().ForEach(type =>
            {
                if (type.GetInterfaces().Any(x => x == typeof(IApplicationManager)) && applicationManagers.ContainsKey(type.BaseType))
                {
                    IApplicationManager instance = Activator.CreateInstance(type) as IApplicationManager;
                    PropertyInfo propertyInfo = type.GetProperties().Where(x => x.PropertyType == typeof(IConfiguration)).FirstOrDefault();
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(instance, configuration);
                    }
                    applicationManagers[type.BaseType] = instance;
                }
            });
        }

        //Commented as later we might think to give order variable in each manager and need to deal with collision strategy or 
        //Can provide a node like linked list which to invoke next in pipeline and then we can utilize the reflection with property injection
        private IEnumerable<IApplicationManager> ScanCurrentAssemblyForManagers(IConfiguration configuration)
        {
            Assembly assembly = typeof(Bootstraper).Assembly;
            var applicationManagers = new List<IApplicationManager>();
            assembly.GetTypes().ToList().ForEach(type =>
            {
                if (type.GetInterfaces().Any(x => x == typeof(IApplicationManager)))
                {
                    var manager = Activator.CreateInstance(type) as IApplicationManager;
                    PropertyInfo propertyInfo = type.GetProperties().FirstOrDefault(x => x.PropertyType == typeof(IConfiguration));
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(manager, configuration);
                    }
                    applicationManagers.Add(manager);
                }
            });
            return applicationManagers;
        }


        public void BuildOutServices(IServiceCollection serviceCollection)
        {
            foreach (var applicationManager in applicationManagers)
            {
                applicationManager.Value.ConfigureService(serviceCollection);
            }

        }

        public void BuildOutApplication(IApplicationBuilder app, IWebHostEnvironment env)
        {
            foreach (var applicationManager in applicationManagers)
            {
                applicationManager.Value.Configure(app, env);
            }

        }
    }
}
