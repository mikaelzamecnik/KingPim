using KingPim.Application.CategoryService.Get;
using KingPim.Application.CategoryService.Modify;
using KingPim.Application.ProductService.Get;
using KingPim.Application.SubCategoryService.Get;
using KingPim.Application.SubCategoryService.Modify;
using KingPim.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KingPim.Web
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

            services.AddDbContext<KingPimDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KingPim")));

            //Configure cors to make the api avalible to other systems
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Services for Categories
            services.AddScoped<ICategoryGetAll, CategoryGetAll>();
            services.AddScoped<ICategoryGetSingle, CategoryGetSingle>();
            services.AddScoped<ICategoryModifyCreate, CategoryModifyCreate>();
            services.AddScoped<ICategoryModifyPut, CategoryModifyPut>();
            services.AddScoped<ICategoryModifyDelete, CategoryModifyDelete>();
            //Services for SubCategories
            services.AddScoped<ISubCategoryGetAll, SubCategoryGetAll>();
            services.AddScoped<ISubCategoryGetSingle, SubCategoryGetSingle>();
            services.AddScoped<ISubCategoryModifyCreate, SubCategoryModifyCreate>();
            services.AddScoped<ISubCategoryModifyPut, SubCategoryModifyPut>();
            services.AddScoped<ISubCategoryModifyDelete, SubCategoryModifyDelete>();
            //Services for Products
            services.AddScoped<IProductGetAll, ProductGetAll>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, KingPimDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            DataSeed.FillIfEmpty(ctx);
        }
    }
}
