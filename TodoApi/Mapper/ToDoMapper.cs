using TodoApi.Dto.ToDo;
using TodoApi.Model;

namespace TodoApi.Mapper;

public static class ToDoMapper
{
    public static ToDoDto ToToDoDto(this ToDoModel toDoModel)
    {
        return new ToDoDto
        {
            Id = toDoModel.Id,
            Title = toDoModel.Title,
            IsDone = toDoModel.IsDone,
        };
    }

    public static ToDoModel ToToDoModel(this CreateToDoDto dto)
    {
        return new ToDoModel
        {
            Title = dto.Title,
        };
    }
}