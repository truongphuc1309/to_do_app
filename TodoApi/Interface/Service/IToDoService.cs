using TodoApi.Dto.ToDo;
using TodoApi.Model;

namespace TodoApi.Interface.Service;

public interface IToDoService
{
    Task<List<ToDoDto>> GetAll();
    Task<ToDoDto> Create(CreateToDoDto dto);
    Task<ToDoDto> Update(int id, UpdateToDoDto request);
    Task<ToDoDto> Delete(int id);
}