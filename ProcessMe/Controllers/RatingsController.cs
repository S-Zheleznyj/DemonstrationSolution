using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
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
        public async Task<IActionResult> Create(RatingRequest ratingRequest)
        {
            var result = await _manager.Create(ratingRequest);

            return CreatedAtAction("Get", ratingRequest, result);
        }

        /// <summary> Редактирует оценку</summary>
        [HttpPut]
        public async Task<IActionResult> Update(Rating rating)
        {
            await _manager.Update(rating);

            return NoContent();
        }
    }
}
