using Microsoft.EntityFrameworkCore;
using Task_Manager_Back.Models;

namespace Task_Manager_Back.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options): base (options) {
            
        }

        public DbSet<TaskItem> TaskItem { get; set; }
    }
}
