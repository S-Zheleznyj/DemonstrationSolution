using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [Authorize(Roles = "Admin,Superadmin")]
    public class RolesController : ProcessMeBaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]string roleName)
        {
            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] string roleName)
        {
            var existed_role = await _roleManager.FindByNameAsync(roleName);
            if (existed_role == null)
                return NotFound($"{roleName} is not exist");

            var result = await _roleManager.DeleteAsync(existed_role);

            return Ok(result);
        }

    }
}
