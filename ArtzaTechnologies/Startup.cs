using ArtzaTechnologies.AutoMapperProfiles;
using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.Services;
using ArtzaTechnologies.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtzaTechnologies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Ajout de Automapper : 
            services.AddAutoMapper();

            AutoMapperConfiguration.Configure();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuration EntityFramework : 
            var connection = @"Server=localhost;Database=Artza_vol;Trusted_Connection=False;Integrated Security=True;";
            services.AddDbContext<AppDomainContext>
                (options => options.UseSqlServer(connection));

            //TODO l'enregistrement IOC doit se faire dans une methode ou dans une classe installer dependency
            // Ajout des services : 
            services.AddScoped<IVolService, VolService>();
            services.AddScoped<IAeroportService, AeroportService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vols}/{action=Index}/{id?}");
            });
        }
    }
}
