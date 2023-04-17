using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
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
        public async Task<IActionResult> Create(DepartmentRequest departmentRequest)
        {
            var result = await _manager.Create(departmentRequest);

            return CreatedAtAction("Get", departmentRequest, result);
        }

        /// <summary> Редактирует департамент</summary>
        [HttpPut]
        public async Task<IActionResult> Update(Department department)
        {
            await _manager.Update(department);

            return NoContent();
        }
    }
}
