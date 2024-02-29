using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using WebApplication1.Repos;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ISPContext>
                (options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ISP")); });
            
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                //option.Password.RequiredLength = 8;
                //option.Password.RequireUppercase = false;
                //option.Password.RequireNonAlphanumeric = false;
                //option.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<ISPContext>();
            builder.Services.AddScoped<IServiceProviderRepo,ServiseProviderRepo>();
            builder.Services.AddScoped<IBranchRepo,BranchRepo>();
<<<<<<< HEAD
            builder.Services.AddScoped<IEmployeeRebo, EmployeeRebo>();

=======
            builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
>>>>>>> dab10b3db535688181ee3807e4a96af56a55280e
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
