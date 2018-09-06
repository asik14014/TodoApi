using AutoMapper;
using $ext_safeprojectname$.API.Common.Attributes;
using $ext_safeprojectname$.API.Common.Settings;
using $ext_safeprojectname$.API.Common.Extensions;
using $ext_safeprojectname$.IoC.Configuration.Profiles;
using $ext_safeprojectname$.Services;
using $ext_safeprojectname$.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace DotNetCore.API1
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public IHostingEnvironment HostingEnvironment { get; private set; }

        private AppSettings _appSettings;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(
                opt => opt.Filters.Add(typeof(CustomFilterAttribute))
                )
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            //App settings
            var appSettingsSection = Configuration.GetSection("AppSettings");
            if (appSettingsSection == null)
                throw new System.Exception("No appsettings section has been found");

            services.Configure<AppSettings>(appSettingsSection);

            _appSettings = appSettingsSection.Get<AppSettings>();

            if (_appSettings.IsValid())
            {
                if (_appSettings.Swagger.Enabled)
                {
                    // Register the Swagger generator, defining 1 or more Swagger documents
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc(_appSettings.API.Version, new Info { Title = _appSettings.API.Title, Version = _appSettings.API.Version });
                    });
                }
            }

            //Automap settings
            services.AddAutoMapper();
            ConfigureMaps();

            //Custom services (.NET CORE 2.1)
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Swagger section
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            if (_appSettings.IsValid())
            {
                if (_appSettings.Swagger.Enabled)
                {                    
                    app.UseSwagger();

                    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                    // specifying the Swagger JSON endpoint.
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint($"/swagger/{_appSettings.API.Version}/swagger.json", _appSettings.API.Title);
                    });
                }
            }

            app.UseMvc();
        }

        private void ConfigureMaps()
        {
            //Mapping settings
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<APIMappingProfile>();
                cfg.AddProfile<ServicesMappingProfile>();
            }
                );
        }
    }
}
