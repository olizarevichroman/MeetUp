using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
      if (ModelState.IsValid)
      {
        var user = new User(registerModel);

        var result = await _userManager.CreateAsync(user, registerModel.Password);
        
        if (result.Succeeded)
        {
          return Ok();
        }
        else
        {
          return BadRequest(result.Errors);
        }      
      }

      return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> IsUserWithEmailExist([FromBody] string email) 
    {
      var user = await _userManager.FindByEmailAsync(email);

      return Ok(user != null);
    }

  }
}
