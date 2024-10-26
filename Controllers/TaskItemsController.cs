using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Manager_Back.Data;
using Task_Manager_Back.Models;

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

        [HttpGet("{Id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(Guid id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null) { 
                return NotFound();
            }
            
            return taskItem;
        }
    }
}
