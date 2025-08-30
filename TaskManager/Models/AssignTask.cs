using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasklyne.Models.Enums;

namespace Tasklyne.Models;

public class AssignTask
{
    public int Id { get; set; }
    [ForeignKey("Tasklist")]
    public int TaskId { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    [DataType(DataType.Date)]
    public DateTime AssignDate { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? SubmitDate { get; set; }
    public Status Status { get; set; } = Status.Pending;
    [StringLength(255, ErrorMessage = "Remarks must be less than or equal to 255 characters.")]
    public string? Remarks { get; set; }
    public Tasklist Tasklist { get; set; }

    [NotMapped]
    public List<Tasklist> Tasklists { get; set; } = new List<Tasklist>();
    [NotMapped]
    public List<Employee> Employees { get; set; } = new List<Employee>();

}
