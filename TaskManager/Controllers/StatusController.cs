using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs.Status;
using TaskManager.Interfaces;
using TaskManager.Mappers;
using TaskManager.Models;

namespace TaskManager.Controllers;
[ApiController]
[Route("api/status")]
public class StatusController: ControllerBase
{
    private readonly IStatusRepository _statusRepository;

    public StatusController(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    [HttpGet("GetAllStatuses")]
    public async Task<IActionResult> GetAllStatuses()
    {
        var statuses = await _statusRepository.GetStatusesAsync();
        var statusesDto = statuses.Select(s => s.ToDto());
        
        return Ok(statusesDto);
    }

    [HttpGet("GetStatusById/{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        var status = await _statusRepository.GetStatusByIdAsync(id);
        if(status == null)
            return NotFound();
        return Ok(status.ToDto());
    }

    [HttpGet("GetStatusByName/{name}")]
    public async Task<IActionResult> GetStatusByName([FromBody]string name)
    {
        var status = await _statusRepository.GetStatusByNameAsync(name);
        if(status == null)
            return NotFound();
        return Ok(status.ToDto());
    }

    [HttpPost("CreateStatus")]
    public async Task<IActionResult> CreateStatus([FromBody] CreateStatusRequestDto statusRequestDto)
    {
        var status = statusRequestDto.ToStatus();
        var creator = await _statusRepository.CreateStatusAsync(status);
        if(creator == null)
            return BadRequest();
        return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status.ToDto());
    }

    [HttpPut("UpdateStatus/{id}")]
    public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] UpdateStatusRequestDto statusRequestDto)
    {
        var status = await _statusRepository.UpdateStatusAsync(id, statusRequestDto);
        if(status == null)
            return NotFound();
        return Ok(status.ToDto());
    }

    [HttpDelete("DeleteStatus/{id}")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
        var status = await _statusRepository.DeleteStatusAsync(id);
        if(status == null)
            return NotFound();
        return NoContent();
    }
}