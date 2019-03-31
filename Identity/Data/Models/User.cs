using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data.Models
{
  public class User : IdentityUser
  {
    public User() { }
    public User(RegisterModel registerModel)
    {
      Email = registerModel.Email;
      Age = registerModel.Age;
      FirstName = registerModel.FirstName;
      SecondName = registerModel.SecondName;
      UserName = registerModel.Email;
    }

    [Required]
    [Range(14, 100)]
    public int Age { get; set; }

    [MaxLength(400)]
    [PersonalData]
    public string AboutMyself { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string SecondName { get; set; }
  }
}
