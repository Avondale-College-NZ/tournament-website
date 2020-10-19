using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tournament_website.Data;

[assembly: HostingStartup(typeof(Tournament_website.Areas.Identity.IdentityHostingStartup))]
namespace Tournament_website.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Tournament_websiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Tournament_websiteContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Tournament_websiteContext>();
            });
        }
    }
}