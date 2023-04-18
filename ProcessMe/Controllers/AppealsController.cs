using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppealsController : ProcessMeBaseController
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
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary> Создает обращение</summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AppealForCreationDto appealRequest)
        {
            var result = await _manager.Create(appealRequest);

            return CreatedAtAction("Get", new { id = result}, result);
        }

        /// <summary> Редактирует обращение</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]Guid id,[FromBody]AppealForCreationDto appealRequest)
        {
            await _manager.Update(id, appealRequest);

            return NoContent();
        }
    }
}
