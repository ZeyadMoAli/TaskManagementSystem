namespace TaskManager.DTOs.Task;

public class TaskDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DeadLine { get; set; }

    public string UserId { get; set; }

    public int StatusId { get; set; }

    public int PriorityId { get; set; }

    public int CategoryId { get; set; }
}