using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using DomainServicesSecurity = Adom.Hhm.Domain.Services.Security;
using AppServicesSecurity = Adom.Hhm.AppServices.Security;
using DomainServices = Adom.Hhm.Domain.Services;
using AppServices = Adom.Hhm.AppServices;

namespace Adom.Hhm.Ioc
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            Configure(services, Data.IoC.Module.GetTypes());
            Configure(services, DomainServicesSecurity.IoC.Module.GetTypes());
            Configure(services, AppServicesSecurity.IoC.Module.GetTypes());
            Configure(services, DomainServices.IoC.Module.GetTypes());
            Configure(services, AppServices.IoC.Module.GetTypes());
        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
                services.AddScoped(type.Key, type.Value);
        }

    }
}
