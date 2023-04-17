using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
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
        public async Task<IActionResult> Create(EmployeeRequest employeeRequest)
        {
            var result = await _manager.Create(employeeRequest);

            return CreatedAtAction("Get", employeeRequest, result);
        }

        /// <summary> Редактирует сотрудника</summary>
        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            await _manager.Update(employee);

            return NoContent();
        }
    }
}
