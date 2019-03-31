using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data;
using Identity.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Identity
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("IdentityDBConnection"));
     });


      services.AddIdentity<User, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;

        options.Lockout.MaxFailedAccessAttempts = 3;
        options.SignIn.RequireConfirmedEmail = true;
      })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }
      //app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseMvc();
    }

    //private IServiceCollection ConfigureIdentity(IServiceCollection services)
    //{
    //  services.Configure<IdentityOptions>(options =>
    //  {
    //    options.Password.RequireNonAlphanumeric = false;
    //    options.Password.RequireDigit = true;
    //    options.Password.RequiredLength = 6;
    //    options.Password.RequireLowercase = true;
    //    options.Password.RequireUppercase = true;


    //    options.Lockout.MaxFailedAccessAttempts = 3;
    //  });

    //  return services;
    //}
  }
}
