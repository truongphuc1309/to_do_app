namespace TodoApi.Dto.ToDo;

public class ToDoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}