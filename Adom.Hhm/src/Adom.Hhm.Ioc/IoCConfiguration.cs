using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;
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
            var mailServerConfig = new MailServerConfig
            {

                //From = new MailAccount("BLUE ADOM SERVICES", "serviciosadom", "xxxxx"),
                From = new MailAccount("BLUE ADOM SERVICES", "servicios.adomsalud@gmail.com", "830001237-4blue"),
                Port = 465,
                Server = "smtp.gmail.com",
                CopyTo = new List<MailAccount> { new MailAccount("Adom Salud", "adomsalud1978@gmail.com") }
            };
            services.AddSingleton(typeof(MailServerConfig), mailServerConfig);
            //services.Configure<MailServerConfig>(mailServerConfig =>
            //{
            //    mailServerConfig.From = new
            //    MailAccount("BLUE ADOM SERVICES", "servicios.adomsalud@gmail.com", "830001237-4blue");
            //    mailServerConfig.Port = 25;
            //    mailServerConfig.Server = "smtp.gmail.com";
            //});
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }

        }

    }
}
