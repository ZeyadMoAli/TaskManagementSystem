using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManager.Models;

public partial class Task
{
    [Key]
    public int Id { get; set; }
    [Required][MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(250)]
    public string? Description { get; set; }
    
    public DateTime DeadLine { get; set; }
    [Required]
     public string UserId { get; set; } = null!;
    
    [Required]
    public int StatusId { get; set; }
    [Required]
    public int PriorityId { get; set; }
    [Required]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
