using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Manager_Back.Data;
using Task_Manager_Back.Models;
using Task_Manager_Back.Dtos;

namespace Task_Manager_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly Context _context;

        public TaskItemsController(Context context)
        {
            
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems() {
            return await _context.TaskItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(Guid id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItemDto taskItemDto)
        {
            var taskItem = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = taskItemDto.Title,
                Description = taskItemDto.Description,
                Status = taskItemDto.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
        }

        private bool TaskItemExists(Guid id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}
