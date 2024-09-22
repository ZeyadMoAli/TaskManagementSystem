using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public partial class Priority
{
    [Key]
    public int Id { get; set; }
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
