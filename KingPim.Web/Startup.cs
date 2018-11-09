using AutoMapper;
using KingPim.Application.Account.Service;
using KingPim.Application.AttributeGroupService.Get;
using KingPim.Application.AttributeGroupService.Modify;
using KingPim.Application.CategoryService.Get;
using KingPim.Application.CategoryService.Modify;
using KingPim.Application.Helpers;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Application.SubCategoryService.Get;
using KingPim.Application.SubCategoryService.Modify;
using KingPim.Persistence;
using KingPim.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            {
                options.UseSqlServer(Configuration.GetConnectionString("KingPim"));

            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //Configure cors to make the api avalible to other systems
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            //Services for Categories
            services.AddScoped<ICategoryGetAll, CategoryGetAll>();
            services.AddScoped<ICategoryGetSingle, CategoryGetSingle>();
            services.AddTransient<ICategoryModifyCreate, CategoryModifyCreate>();
            services.AddTransient<ICategoryModifyPut, CategoryModifyPut>();
            services.AddScoped<ICategoryModifyDelete, CategoryModifyDelete>();
            //Services for SubCategories
            services.AddScoped<ISubCategoryGetAll, SubCategoryGetAll>();
            services.AddScoped<ISubCategoryGetSingle, SubCategoryGetSingle>();
            services.AddTransient<ISubCategoryModifyCreate, SubCategoryModifyCreate>();
            services.AddTransient<ISubCategoryModifyPut, SubCategoryModifyPut>();
            services.AddScoped<ISubCategoryModifyDelete, SubCategoryModifyDelete>();
            //Services for Products
            services.AddScoped<IProductGetAll, ProductGetAll>();
            services.AddScoped<IProductGetSingle, ProductGetSingle>();
            services.AddTransient<IProductModifyCreate, ProductModifyCreate>();
            services.AddTransient<IProductModifyPut, ProductModifyPut>();
            services.AddScoped<IProductModifyDelete, ProductModifyDelete>();
            //Services for AttributeGroups
            services.AddScoped<IAgGetAll, AgGetAll>();
            services.AddScoped<IAgGetSingle, AgGetSingle>();
            services.AddTransient<IAgModifyCreate, AgModifyCreate>();
            services.AddTransient<IAgModifyPut, AgModifyPut>();
            services.AddScoped<IAgModifyDelete, AgModifyDelete>();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, KingPimDbContext ctx)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Easier to read Error handling
          app.UseExceptionHandler(
          builder =>
            {
            builder.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                var error = context.Features.Get<IExceptionHandlerFeature>();
                if (error != null)
                {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                }
            });
            });

            app.UseAuthentication();
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
