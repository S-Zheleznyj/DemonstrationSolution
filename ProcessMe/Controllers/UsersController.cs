using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _manager;
        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает всех пользователей</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает пользователя по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает пользователя</summary>
        [HttpPost]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            var result = await _manager.Create(userRequest);

            return CreatedAtAction("Get", new { id = result }, result);
        }

        /// <summary> Редактирует пользователя</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UserRequest userRequest)
        {
            await _manager.Update(id, userRequest);

            return NoContent();
        }
    }
}
