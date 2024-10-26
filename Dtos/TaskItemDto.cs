namespace Task_Manager_Back.Dtos
{
    public class TaskItemDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }
}
