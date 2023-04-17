using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    public class EmployeesController : ProcessMeBaseController
    {
        private readonly IEmployeeManager _manager;
        public EmployeesController(IEmployeeManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает всех сотрудников</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает сотрудника по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает сотрудника</summary>
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeForCreationDto employeeRequest)
        {
            var result = await _manager.Create(employeeRequest);

            return CreatedAtAction("Get", new { id = result }, result);
        }

        /// <summary> Редактирует сотрудника</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] EmployeeForCreationDto employeeRequest)
        {
            await _manager.Update(id, employeeRequest);

            return NoContent();
        }
    }
}
