namespace TaskManager.DTOs.Task;

public class UpdateTaskRequestDto
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DeadLine { get; set; }
    
    public int StatusId { get; set; }

    public int PriorityId { get; set; }

    public int CategoryId { get; set; }
}