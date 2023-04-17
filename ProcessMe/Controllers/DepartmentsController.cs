using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    public class DepartmentsController : ProcessMeBaseController
    {
        private readonly IDepartmentManager _manager;
        public DepartmentsController(IDepartmentManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает все департаменты</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает департамент по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает департамент</summary>
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentForCreationDto departmentRequest)
        {
            var result = await _manager.Create(departmentRequest);

            return CreatedAtAction("Get", new { id = result }, result);
        }

        /// <summary> Редактирует департамент</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] DepartmentForCreationDto departmentRequest)
        {
            await _manager.Update(id, departmentRequest);

            return NoContent();
        }
    }
}
