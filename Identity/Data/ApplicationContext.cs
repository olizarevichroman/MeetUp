using Identity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data
{
  public class ApplicationContext : IdentityDbContext<User>
  {
    public ApplicationContext(DbContextOptions contextOptions) 
      : base(contextOptions)
    {
      Database.EnsureCreated();
    }


  }
}
