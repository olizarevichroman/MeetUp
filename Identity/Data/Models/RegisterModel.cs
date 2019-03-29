using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data.Models
{
  public class RegisterModel
  {
    [Required]
    public string Email { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string SecondName { get; set; }

    [Required]
    [Range(14, 100)]
    public int Age { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }
  }
}
