using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Adom.Hhm.AppServices.Security.Interfaces;
using Adom.Hhm.Web.Rest.Validators;

namespace Adom.Hhm.Web.Rest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private readonly SymmetricSecurityKey signingKey;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            Configuration = builder.Build();
            string key = Configuration["SecretKeyJWT"];
            signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddOptions();
            services.AddSingleton(Configuration);
            this.AddServicesValidators(services);
            Ioc.IoCConfiguration.Configure(services);
            services.AddScoped<IDbConnection>(c => new SqlConnection(Configuration["ConnectionString"]));
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            var serviceProvider = services.BuildServiceProvider();
            var serviceAuthorization = serviceProvider.GetService<IAuthorizationAppService>();
            services.AddAuthorization(serviceAuthorization.GetPolicies());

            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("CorsPolicy");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseMvc();
        }

        private void AddServicesValidators(IServiceCollection services)
        {
            services.AddScoped<UserValidator>();
            services.AddScoped<RoleValidator>();
            services.AddScoped<UserRoleValidator>();
            services.AddScoped<RoleActionResourceValidator>();
            services.AddScoped<PatientValidator>();
            services.AddScoped<ProfessionalValidator>();
            services.AddScoped<CoordinatorValidator>();
            services.AddScoped<EntityValidator>();
            services.AddScoped<SupplyValidator>();
            services.AddScoped<ServiceValidator>();
            services.AddScoped<ServiceFrecuencyValidator>();
            services.AddScoped<CoPaymentFrecuencyValidator>();
            services.AddScoped<PlanRateValidator>();
            services.AddScoped<AssignServiceValidator>();
            services.AddScoped<AssignServiceDetailValidator>();
            services.AddScoped<AssignServiceSupplyValidator>();
            services.AddScoped<PlanEntityValidator>();
        }
    }
}
