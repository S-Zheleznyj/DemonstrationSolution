using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleManager _manager;
        public RolesController(IRoleManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает все роли</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает роль по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает оценку</summary>
        [HttpPost]
        public async Task<IActionResult> Create(RoleRequest roleRequest)
        {
            var result = await _manager.Create(roleRequest);

            return CreatedAtAction("Get", roleRequest, result);
        }

        /// <summary> Редактирует роль</summary>
        [HttpPost]
        public async Task<IActionResult> Update(Role role)
        {
            await _manager.Update(role);

            return NoContent();
        }
    }
}
