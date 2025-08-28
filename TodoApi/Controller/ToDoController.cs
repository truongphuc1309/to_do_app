using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto;
using TodoApi.Dto.ToDo;
using TodoApi.Interface.Service;

namespace TodoApi.Controller;

[Route("/api/todo")]
[ApiController]
public class ToDoController (IToDoService _toDoService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =  await _toDoService.GetAll();
        return Ok(new ApiResponse<List<ToDoDto>>
        {
            Data = result,
            Message = "Get All ToDo Success"
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateToDoDto request)
    {
        var result = await _toDoService.Create(request);
        return Ok(new ApiResponse<ToDoDto>
        {
            Data = result,
            Message = "Created ToDo Success"
        });
    }
    
    [HttpPut("{id:int}")] 
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateToDoDto request)
    {
        var result = await _toDoService.Update(id, request);
        return Ok(new ApiResponse<ToDoDto>
        {
            Data = result,
            Message = "Updated ToDo Success"
        });
    }
    
    [HttpDelete("{id:int}")] 
    public async Task<IActionResult> Deleted ([FromRoute] int id)
    {
        var result = await _toDoService.Delete(id);
        return Ok(new ApiResponse<ToDoDto>
        {
            Data = result,
            Message = "Deleted ToDo Success"
        });
    }

}