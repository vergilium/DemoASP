using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainContext;
using DomainRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DemoASP.WebAPP
{
    public class Startup
    {
        private readonly string _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string postgresPassword = Environment.GetEnvironmentVariable("PGPASSWORD") ?? "postgres";
            _connectionString = configuration.GetConnectionString("DBConnection"); //.Replace("###", postgresPassword);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Controllers and Views for Login
            services.AddControllersWithViews();

            services.AddDbContext<MyDbContext>(options => { 
                options.EnableSensitiveDataLogging();
                options.UseNpgsql(_connectionString,
                    innerOptions =>
                    {
                        innerOptions.MigrationsAssembly("DemoASP.WebAPP");
                        innerOptions.SetPostgresVersion(new Version(12, 10));
                    });

            }, ServiceLifetime.Transient);

        //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IMarkRepository, MarkRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();

            services.AddDefaultIdentity<IdentityUser>(
                   options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<MyDbContext>();

            services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireLoggedId", policy => policy.RequireRole("Administrators", "Moderators").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdministrator", policy => policy.RequireRole("Administrators").RequireAuthenticatedUser());
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout SignIn settings.
                //options.SignIn.RequireConfirmedAccount = true;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                //options.LoginPath = "/Identity/Account/Login";
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                //options.SlidingExpiration = true;
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
                
                //for login
                endpoints.MapRazorPages();
            });

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope != null)
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();
            }

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //context.Database.Migrate();
        }
    }
}
