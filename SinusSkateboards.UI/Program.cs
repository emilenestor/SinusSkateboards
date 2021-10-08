using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SinusSkateboards.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			//Create Admin-User
			try
			{
				using (var scope = host.Services.CreateScope())
				{
					var context = scope.ServiceProvider.GetRequiredService<SinusDbContext>();
					var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
					context.Database.Migrate();
					if (!context.Users.Any())
					{
						var adminUser = new IdentityUser()
						{
							UserName = "admin"
						};
						var result = userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			//Init API

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
