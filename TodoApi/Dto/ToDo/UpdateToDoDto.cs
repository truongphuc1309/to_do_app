using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto.ToDo;

public class UpdateToDoDto(string title, bool isDone)
{
    [Required]
    public string Title { get; set; } = title;
    
    [Required]
    public bool IsDone { get; set; } = isDone;
}