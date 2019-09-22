using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebStore.Clients.Value;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
using WebStore.Interface.Api;
using WebStore.Interface.Services;
using WebStore.ViewModel;
using WebStore.Infrastucture;
using WebStore.Infrastucture.Implementations;
using WebStore.Infrastucture.Interfaces;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IEmployeesData, InMemoryEmployeeData>();
            services.AddSingleton<IProductService, InMemoryProductService>();
            services.AddScoped<IProductService, SqlProductService>();

            services.AddDbContext<WebStoreContext>(optionsAction: options => options.UseSqlServer(
                Configuration.GetConnectionString(name: "DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders()
                ;

            services.AddTransient<IValueService, ValuesClient>();
            //    services.Configure<IdentityOptions>(options =>
            //    {
            //        //Password settings
            //        options.Password.RequiredLength = 6;

            //        //Lockout settings
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //        options.Lockout.MaxFailedAccessAttempts = 10;
            //        options.Lockout.AllowedForNewUsers = true;

            //        //User settings
            //        options.User.RequireUniqueEmail = true;
            //    });

            //    services.ConfigureApplicationCookie(options =>
            //    {
            //        options.Cookie.HttpOnly = true;
            //        options.Cookie.Expiration = TimeSpan.FromDays(150);
            //        options.LoginPath = "/Account/Login";
            //        options.LogoutPath = "/Account/Logout";
            //        options.AccessDeniedPath = "/Account/AccessDenied";
            //        options.SlidingExpiration = true;
            //    });

            //Насторойки для корзины товаров
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookeCartService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<TokenMiddleware>();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes=>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{Id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
