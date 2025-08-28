using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto.ToDo;

public class CreateToDoDto
{
    [Required]
    public string Title { get; set; }
}