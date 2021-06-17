using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_PS04.DAL;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Zajecia_PS04.Utils;

namespace Zajecia_PS04
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
            //React
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            services.AddJsEngineSwitcher(options =>
                options.DefaultEngineName = V8JsEngine.EngineName).AddV8();

            
            //EndReact 
    
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.HttpOnly = true;
                    config.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None;
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/Login/UserLogin";
                    config.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                });

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/admin");
                options.Conventions.AuthorizeFolder("/ManageProduct");
                
            });

            services.AddRazorPages().AddMvcOptions(options =>
            {
                options.Filters.Add(new CustomPageFilter(Configuration));
            });

            //services.Add(new ServiceDescriptor(typeof(IproductDB), new ProductXmlDB(Configuration)));
            services.Add(new ServiceDescriptor(typeof(IproductDB), new ProductSQLDB(Configuration)));
            services.Add(new ServiceDescriptor(typeof(IUser), new UserSQLDB(Configuration)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseReact(config =>
            {
                config.AddScript("~/js/first.jsx");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //sesja
            app.UseSession();
            //--

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                //added
                endpoints.MapControllers();
            });
        }
    }
}
