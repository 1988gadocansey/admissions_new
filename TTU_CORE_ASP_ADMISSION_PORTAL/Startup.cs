using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp.Web.DependencyInjection;
using Microsoft.IO;
using System.Net;
using TTU_CORE_ASP_ADMISSION_PORTAL.Extensions;
using TTU_CORE_ASP_ADMISSION_PORTAL.Services;
using Microsoft.AspNetCore.Http;

namespace TTU_CORE_ASP_ADMISSION_PORTAL
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
            /**services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();**/


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
            Configuration.GetConnectionString("DefaultConnection")));


            _ = services.AddDefaultIdentity<Models.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
               
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()

                .AddDefaultTokenProviders();
            ;

            services.AddControllersWithViews();


            //configure identity options
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            services.AddScoped<IHelper, HelperService>();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = $"/Identity/Account/Login";
                
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.Configure<DataProtectionTokenProviderOptions>(o =>
            o.TokenLifespan = TimeSpan.FromHours(3));
           

            services.AddControllersWithViews();
            services.AddControllers();
            services.AddRazorPages();
            services.AddHealthChecks();
            
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddHealthChecks();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });
            services.AddImageSharp(
            options =>
            {
                // You only need to set the options you want to change here
                // All properties have been listed for demonstration purposes
                // only.
                
                options.MemoryStreamManager = new RecyclableMemoryStreamManager();
                options.BrowserMaxAge = TimeSpan.FromDays(7);
               // options.CacheMaxAge = TimeSpan.FromDays(365);
               // options.CachedNameLength = 8;
                options.OnParseCommandsAsync = _ => Task.CompletedTask;
                options.OnBeforeSaveAsync = _ => Task.CompletedTask;
                options.OnProcessedAsync = _ => Task.CompletedTask;
                options.OnPrepareResponseAsync = _ => Task.CompletedTask;
            });

            //services.AddImageResizer();
            //services.AddSingleton<IMageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseImageSharp();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                
                endpoints.MapHealthChecks("/health");

                //endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                //endpoints.MapPost("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
            });
            //app.UseImageResizer();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home";
                    await next();
                }
            });
        }
    }
}
