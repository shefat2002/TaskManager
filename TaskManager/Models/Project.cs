﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models;

public class Project
{
    public int Id { get; set; }
    [Required(ErrorMessage = "You must enter the Project Name!")]
    [StringLength(30, ErrorMessage = "Project Name must be less than or equal to 30 characters.")]
    public string Name { get; set; }
    [StringLength(255, ErrorMessage = "Project Description must be less than or equal to 255 characters.")]
    public string? Description { get; set; }
    [NotMapped]
    public ICollection<Tasklist> Tasklists { get; set; } = new List<Tasklist>();
}
