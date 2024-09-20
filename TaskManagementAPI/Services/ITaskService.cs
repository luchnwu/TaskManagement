using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync();

        Task<TaskItem?> GetTaskByIdAsync(int id);

        Task CreateTaskAsync(TaskItem task);

        Task DeleteTaskByIdAsync(int id);

        Task UpdateTaskAsync(TaskItem task);
    }
}
