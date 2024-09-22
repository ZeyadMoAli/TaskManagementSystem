using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs.Priority;
using TaskManager.Interfaces;
using TaskManager.Mappers;
using TaskManager.Models;

namespace TaskManager.Controllers;
[ApiController][Route("api/priority")]
public class PriorityController: ControllerBase
{
    private readonly IPriorityRepository _priorityRepository;

    public PriorityController(IPriorityRepository priorityRepository)
    {
        _priorityRepository = priorityRepository;
    }

    [HttpGet("GetAllPriorities")]
    public async Task<IActionResult> GetAllPriority()
    {
        var priorities  = await _priorityRepository.GetPrioritiesAsync();
        var prioritiesDto = priorities.Select(p => p.ToDto());
        return Ok(prioritiesDto);
    }

    [HttpGet("GetPriorityById/{Id}")]
    public async Task<IActionResult> GetPriorityById(int Id)
    {
        var priority = await _priorityRepository.GetPriorityByIdAsync(Id);
        if(priority == null)
            return NotFound();
        return Ok(priority.ToDto());
    }

    [HttpGet("GetPriorityByName/{name}")]
    public async Task<IActionResult> GetPriorityByName([FromBody]string name)
    {
        var priority = await _priorityRepository.GetPriorityByNameAsync(name);
        if(priority == null)
            return NotFound();
        return Ok(priority.ToDto());
    }

    [HttpPost("CreatePriority")]
    public async Task<IActionResult> AddPriority([FromBody] CreatePriorityRequestDto prioritydto)
    {
        var priority = prioritydto.ToPriority();
        var newPriority = await _priorityRepository.CreatePriorityAsync(priority);
        if(newPriority == null)
            return BadRequest();
        return Ok(newPriority.ToDto());
    }

    [HttpPut("UpdatePriority/{Id}")]
    public async Task<IActionResult> UpdatePriority([FromRoute]int Id, [FromBody] UpdatePriorityRequestDto prioritydto)
    {
        var priority = await _priorityRepository.UpdatePriorityAsync(Id, prioritydto);
        if(priority == null)
            return BadRequest();
        
        return Ok(priority.ToDto());
    }

    [HttpDelete("DeletePriority/{Id}")]
    public async Task<IActionResult> DeletePriority(int Id)
    {
        var priority = await _priorityRepository.DeletePriorityAsync(Id);
        if(priority == null)
            return BadRequest();
        return NoContent();
    }
}