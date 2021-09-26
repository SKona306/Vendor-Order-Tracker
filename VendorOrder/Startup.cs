using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VendorOrder
{
  public class Startup
  {
    public Startup(IWebHostEnviroment env)
    {
      var builder = new ConfigurationBuilder()
      .SetBasePath(env.ContentRootPath)
      .AddEnviromentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionsPage();
      app.UseRouting();

      app.UseEndPoints(routes => 
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      app.Run(async (context) => 
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}