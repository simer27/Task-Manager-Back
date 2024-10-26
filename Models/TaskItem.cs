using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Manager_Back.Models
{
    [Table("tasks")]
    public class TaskItem
    {
        [Key]
        [Column("Id")]
        [Display(Name = "ID")]
        public Guid Id { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public TaskItem() { }


        public TaskItem(string title, string description, TaskStatus status) {
        
            Title = title;
            Description = description;
            Status = status;
        }
    }
}
