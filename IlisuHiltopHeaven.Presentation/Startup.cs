using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.MVC.Filters;
using IlisuHiltopHeaven.Presentation.Helpers.Abstract;
using IlisuHiltopHeaven.Presentation.Helpers.Concrete;
using IlisuHiltopHeaven.Services.Extensions;
using IlisuHiltopHeaven.Shared.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            //.AddDataAnnotationsLocalization(options => {
            //    options.DataAnnotationLocalizerProvider = (type, factory) =>
            //        factory.Create(typeof(SharedResource));
            //});
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("az-Latn-AZ"),
                    new CultureInfo("en-US"),
                    new CultureInfo("ru-RU")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "az-Latn-AZ", uiCulture: "az-Latn-AZ");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            services.AddControllersWithViews(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Sahə tələb olunur.");
                //options.Filters.Add<MvcExceptionFilter>();
            }).AddRazorRuntimeCompilation().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); //convert enum to json string
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // prevent error while converting included model in the model to json
            }).AddNToastNotifyToastr();

            services.AddSession();
            /*services.AddAutoMapper();*/ // add mapper profile to use
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/admin/auth/login");
                options.LogoutPath = new PathString("/admin/auth/logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "IlisuHiltopHeaven",
                    HttpOnly = true, // Prevent to Get Session Information from UI
                    SameSite = SameSiteMode.Strict, // (CSRF - Cross Site Request Forgery) Prevent Fake Request from Others
                    SecurePolicy = CookieSecurePolicy.SameAsRequest, // Allow to Request From HTTP and HTTPS (Use "Always" - Means Only HTTPS)
                };
                options.SlidingExpiration = true; // Cookie Expiration Time
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7); // Expiration Time - 7 Days
                options.AccessDeniedPath = new PathString("/admin/auth/accessdenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseNToastNotify();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
