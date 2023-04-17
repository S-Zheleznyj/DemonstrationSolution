using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppealsController : ControllerBase
    {
        private readonly IAppealManager _manager;
        public AppealsController(IAppealManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает все обращения</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает обращение по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает обращение</summary>
        [HttpPost]
        public async Task<IActionResult> Create(AppealRequest appealRequest)
        {
            var result = await _manager.Create(appealRequest);

            return CreatedAtAction("Get", appealRequest, result);
        }

        /// <summary> Редактирует обращение</summary>
        [HttpPost]
        public async Task<IActionResult> Update(Appeal appeal)
        {
            await _manager.Update(appeal);

            return NoContent();
        }
    }
}
