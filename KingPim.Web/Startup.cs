using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Data.DataAccess;
using KingPim.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace KingPim.Web
{
    public class Startup
    {
        // IConfiguration is what you use to get info from the appsettings.json file.
        IConfiguration _configuration;
        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                // To return data in XML.
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();
            
            // So the Json() in the controller will return correctly..
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuration for DB connection.
            var conn = _configuration.GetConnectionString("KingPim");

            // Register all services here:
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conn));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubcategoryRepository, SubcategoryRepository>();
            services.AddTransient<IAttributeGroupRepository, AttributeGroupRepository>();
            services.AddTransient<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            services.AddTransient<ISubcategoryAttributeGroupRepository, SubcategoryAttributeGroupRepository>();
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx)
        //IIdentitySeeder identitySeeder
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            
            app.UseStaticFiles();   // To get access to the wwwroot files.
            app.UseMvcWithDefaultRoute();   // Enables default file mapping on the web root.
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var runIdentitySeed = Task.Run(async () => await identitySeeder.CreateAdminAccountIfEmpty()).Result;
            //Seed.FillIfEmpty(ctx);
        }
    }
}
