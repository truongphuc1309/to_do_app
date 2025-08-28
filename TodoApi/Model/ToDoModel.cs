using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Model;

[Table("ToDo")]
public class ToDoModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}