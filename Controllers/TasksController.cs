using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _taskService.GetUserTasks(GetUserId());
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(TaskDto dto)
    {
        var task = await _taskService.CreateTask(GetUserId(), dto);
        return Ok(task);
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> CompleteTask(int id)
    {
        var result = await _taskService.CompleteTask(id, GetUserId());
        if (!result) return NotFound("Task not found");
        return Ok("Task completed!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var result = await _taskService.DeleteTask(id, GetUserId());
        if (!result) return NotFound("Task not found");
        return NoContent();
    }
}