using IncIncWeb.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// ReSharper disable once RedundantUsingDirective
namespace IncIncWeb
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			// Allow .NET Core Version 2.1 to be considered compatible
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			// Here, we disable endpoint routing. It was an issue in upgrading from .NET Core 2.0
			services.AddMvc(options => options.EnableEndpointRouting = false);
			// Adding the connection string! Always just like this for our purposes.
			string connection =
				@"Server=(localdb)\mssqllocaldb;Database=ASPDatabase;Trusted_Connection=true";
			// Adding the DB context
			services.AddDbContext<WorkerContext>(options => options.UseSqlServer(connection));
		}

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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
