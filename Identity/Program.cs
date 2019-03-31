using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = new WebHostBuilder();
      builder.UseKestrel(opt =>
      {
        opt.ListenAnyIP(41537);
      })
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseStartup<Startup>()
      .ConfigureAppConfiguration(o =>
      {
        o.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
      })
      .Build()
      .Run();
      //CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
