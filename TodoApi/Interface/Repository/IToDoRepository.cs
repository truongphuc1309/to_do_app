using TodoApi.Dto.ToDo;
using TodoApi.Model;

namespace TodoApi.Interface.Repository;

public interface IToDoRepository
{
    Task<List<ToDoModel>> GetAll();
    Task<ToDoModel> Create(ToDoModel toDoModel);
    Task<ToDoModel?> GetById(int id);
    Task<ToDoModel> Update(ToDoModel toDoModel);
    Task<ToDoModel> Delete(ToDoModel toDoModel);
}