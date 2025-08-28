using TodoApi.Dto.ToDo;
using TodoApi.Interface.Repository;
using TodoApi.Interface.Service;
using TodoApi.Mapper;
using TodoApi.Model;

namespace TodoApi.Service;

public class ToDoService (IToDoRepository _toDoRepository) : IToDoService
{
    public async Task<List<ToDoDto>> GetAll()
    {
        var toDos = await _toDoRepository.GetAll();
        return toDos.Select(t => t.ToToDoDto()).ToList();
    }

    public async Task<ToDoDto> Create(CreateToDoDto dto)
    {
        var toDoModel = dto.ToToDoModel();
        return (await _toDoRepository.Create(toDoModel)).ToToDoDto();
    }

    public async Task<ToDoDto> Update(int id, UpdateToDoDto request)
    {
        var foundToDo = await _toDoRepository.GetById(id);
        if (foundToDo == null)
            throw new KeyNotFoundException("Invalid Id");
        
        foundToDo.Title = request.Title;
        foundToDo.IsDone = request.IsDone;
        
        var result = await _toDoRepository.Update(foundToDo);
        return result.ToToDoDto();
    }

    public async Task<ToDoDto> Delete(int id)
    {
        var foundToDo = await _toDoRepository.GetById(id);
        if (foundToDo == null)
            throw new KeyNotFoundException("Invalid Id");
        
        var result = await _toDoRepository.Delete(foundToDo);
        return result.ToToDoDto();
    }
}