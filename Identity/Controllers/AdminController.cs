using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]

  public class AdminController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
    }
    // GET api/values
    [HttpPost]
    public async Task<IActionResult> LockoutUserById([FromBody] string userId)
    {
      var userToLock = await _userManager.FindByIdAsync(userId);

      if (userToLock == null)
      {
        return BadRequest();
      }

      var result = await _userManager.SetLockoutEnabledAsync(userToLock, true);

      if (result.Succeeded)
      {
        return Ok();
      }
      else
      {
        return BadRequest(result.Errors);
      }
    }
    
    [HttpPost]
    public async Task<IActionResult> AssignRoleByEmail([FromBody] AssignRoleModel assignRoleModel)
    {
      var user = await _userManager.FindByEmailAsync(assignRoleModel.Email);

      if (user == null)
      {
        return BadRequest();
      }

      var isRoleExist = await _roleManager.RoleExistsAsync(assignRoleModel.RoleName);

      if (isRoleExist == false)
      {
        return BadRequest();
      }

      var roleAssigningResult = await _userManager.AddToRoleAsync(user, assignRoleModel.RoleName);

      if (roleAssigningResult.Succeeded)
      {
        return Ok();
      }
      else
      {
        return BadRequest(roleAssigningResult.Errors);
      }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
      var roleCreationResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

      if (roleCreationResult.Succeeded)
      {
        return Ok();
      }
      else
      {
        return BadRequest(roleCreationResult.Errors);
      }
    }
    
  }
}
