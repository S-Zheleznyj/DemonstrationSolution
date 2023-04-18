using Microsoft.AspNetCore.Mvc;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Controllers
{
    //public class RolesController : ProcessMeBaseController
    //{
    //    private readonly IRoleManager _manager;
    //    public RolesController(IRoleManager manager)
    //    {
    //        _manager = manager;
    //    }
    //    /// <summary> Возвращает все роли</summary>
    //    [HttpGet]
    //    public async Task<IActionResult> GetItems()
    //    {
    //        var result = await _manager.GetItems();

    //        return Ok(result);
    //    }

    //    /// <summary> Возвращает роль по указанному id</summary>
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> Get(Guid id)
    //    {
    //        var result = await _manager.GetItem(id);

    //        return Ok(result);
    //    }

    //    /// <summary> Создает оценку</summary>
    //    [HttpPost]
    //    public async Task<IActionResult> Create(RoleForCreationDto roleRequest)
    //    {
    //        var result = await _manager.Create(roleRequest);

    //        return CreatedAtAction("Get", new { id = result }, result);
    //    }

    //    /// <summary> Редактирует роль</summary>
    //    [HttpPut]
    //    public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] RoleForCreationDto roleRequest)
    //    {
    //        await _manager.Update(id, roleRequest);

    //        return NoContent();
    //    }
    //}
}
