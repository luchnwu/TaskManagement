namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        /// <summary>
        /// "High", "Medium", "Low"
        /// </summary>
        public string Priority { get; set; } = null!;

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}
