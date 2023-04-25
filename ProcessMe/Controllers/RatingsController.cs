using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatingsController : ProcessMeBaseController
    {
        private readonly IRatingManager _manager;
        public RatingsController(IRatingManager manager)
        {
            _manager = manager;
        }
        /// <summary> Возвращает все оценки</summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _manager.GetItems();

            return Ok(result);
        }

        /// <summary> Возвращает оценку по указанному id</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _manager.GetItem(id);

            return Ok(result);
        }

        /// <summary> Создает оценку</summary>
        [HttpPost]
        public async Task<IActionResult> Create(RatingForCreationDto ratingRequest)
        {
            var result = await _manager.Create(ratingRequest);

            return CreatedAtAction("Get", new { id = result }, result);
        }

        /// <summary> Редактирует оценку</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] RatingForCreationDto ratingRequest)
        {
            await _manager.Update(id, ratingRequest);

            return NoContent();
        }
    }
}
