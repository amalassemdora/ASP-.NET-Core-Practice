using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core1.Models;
namespace Core1
{
	public class Startup
	{
		public IConfiguration config;
		public Startup(IConfiguration config)
		{
			this.config = config;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			//Regiter Db context
			services.AddDbContext<ITIContext>(o => o.UseSqlServer(config.GetConnectionString("iticon")));

			//Register to MVC dependency
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseStaticFiles();
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				//Routing to MVC
				endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=index}/{id?}");
				//endpoints.MapGet("/", async context =>
				//{
				//	await context.Response.WriteAsync("Hello World!");
				//});
			});
		}
	}
}
