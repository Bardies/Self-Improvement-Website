using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using SelfDevelopmentApp.Utilities;

namespace SelfDevelopmentApp
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IToDoListRepository, ToDoListRepoService>();
            services.AddScoped<IToDoItemRepository, ToDoItemRepoService>();
            services.AddScoped<IArticleRepository, ArticleRepoService>();
            services.AddScoped<ITopicRepository, TopicRepoService>();
            services.AddScoped<IUserRepository, UserRepoService>();
	    services.AddScoped<IHabitRepository, HabitRepoService>();

            services.Configure<EmailConfig>(configuration.GetSection("Email"));
            services.AddTransient<IEmailRepository, EmailRepoService>();
            services.AddDbContext<AppDbContext>((options) =>
            options.UseSqlServer(configuration.GetConnectionString("stConn"))
            );
            services.AddControllersWithViews();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                // // options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();

            //    //After going down the pipeline check if we 404'd. 
            //    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            //    {
            //        await context.Response.WriteAsync("Woops! We 404'd");
            //    }
            //});
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Shared/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseExceptionHandler("/Shared/Error");
            //app.UseStatusCodePages();
            //app.UseStatusCodePagesWithReExecute("/Home/cust_Error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }



    }
}
