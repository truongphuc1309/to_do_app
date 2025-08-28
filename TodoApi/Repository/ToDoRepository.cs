using Microsoft.EntityFrameworkCore;
using TodoApi.Config;
using TodoApi.Interface.Repository;
using TodoApi.Model;

namespace TodoApi.Repository;

public class ToDoRepository (ApplicationDbContext _context) : IToDoRepository
{
    public  async Task<List<ToDoModel>> GetAll()
    {
        return await _context.ToDo.ToListAsync();
    }

    public async Task<ToDoModel> Create(ToDoModel toDoModel)
    {
        await _context.ToDo.AddAsync(toDoModel);
        await _context.SaveChangesAsync();
        return toDoModel;
    }

    public async Task<ToDoModel?> GetById(int id)
    {
        var result =  await _context.ToDo.FirstOrDefaultAsync(t => t.Id == id);
        return result;
    }

    public async Task<ToDoModel> Update(ToDoModel toDoModel)
    {
        _context.ToDo.Update(toDoModel);
        await _context.SaveChangesAsync();
        return toDoModel;
    }

    public async Task<ToDoModel> Delete(ToDoModel toDoModel)
    {
        _context.ToDo.Remove(toDoModel);
        await _context.SaveChangesAsync();
        return toDoModel;
    }
}