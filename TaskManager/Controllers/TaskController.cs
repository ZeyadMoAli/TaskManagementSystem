using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs.Priority;
using TaskManager.DTOs.Task;
using TaskManager.Interfaces;
using TaskManager.Mappers;

namespace TaskManager.Controllers;
[ApiController][Route("api/tasks")]
public class TaskController: ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet("GetAllTasks")]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks =await  _taskRepository.GetTasksAsync();
        var tasksDto = tasks.Select(t=>t.ToDto());
        return Ok(tasksDto);
    }

    [HttpGet("GetTaskById/{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        if(task is null)
            return NotFound();
        return Ok(task.ToDto());
    }

    [HttpGet("GetTasksByTitle/{title}")]
    public async Task<IActionResult> GetTasksByTitle(string title)
    {
        var task = await _taskRepository.GetTaskByTitleAsync(title);
        if(task is null)
            return NotFound();
        return Ok(task.ToDto());
    }

    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateTask([FromBody]CreateTaskRequestDto taskDto)
    {
        var task = taskDto.ToTask();
        var newTask = await _taskRepository.CreateTaskAsync(task);
        if(newTask is null)
            return BadRequest();
        return Ok(newTask.ToDto());
    }

    [HttpPut("UpdateTask/{id}")]
    public async Task<IActionResult> UpdateTask([FromRoute]int id, [FromBody]UpdateTaskRequestDto taskDto)
    {
        var task = await _taskRepository.UpdateTaskAsync(id, taskDto);
        if(task is null)
            return BadRequest();
        
        return Ok(task.ToDto());
        
    }

    [HttpDelete("DeleteTask/{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _taskRepository.DeleteTaskAsync(id);
        if(task is null)
            return NotFound();
        return NoContent();
    }
}