using TaskManager.DTOs.Priority;
using TaskManager.DTOs.Task;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Mappers;

public static class TaskMapper
{
    public static TaskDto ToDto(this Task task)
    {
        return new TaskDto {Id = task.Id, Title = task.Title, Description = task.Description, PriorityId= task.PriorityId, CategoryId = task.CategoryId, DeadLine = task.DeadLine,StatusId = task.StatusId, UserId = task.UserId};
    }

    public static Task ToTask(this CreateTaskRequestDto taskDto)
    {
        return new Task
        {
            
            UserId = taskDto.UserId,
            Title = taskDto.Title,
            Description = taskDto.Description,
            DeadLine = taskDto.DeadLine,
            StatusId = taskDto.StatusId,
            PriorityId = taskDto.PriorityId,
            CategoryId = taskDto.CategoryId,
        };
    }
}