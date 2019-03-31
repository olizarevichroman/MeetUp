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
      var webHostBuilder = new WebHostBuilder();
      webHostBuilder.UseKestrel(options =>
      {
        options.ListenAnyIP(41537);
      });

      webHostBuilder
        .UseStartup<Startup>()
        .Build()
        .Run();
    }

    //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //    WebHost.CreateDefaultBuilder(args)
    //        .UseStartup<Startup>();
  }
}
