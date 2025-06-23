
namespace TaskManager.Domain.Task
{
    public interface ITaskItemChange
    {
        /// <summary>
        /// Можно ли завершить задачу
        /// </summary>
        /// <returns></returns>
        bool CanBeDone();

        /// <summary>
        /// Смена статуса
        /// </summary>
        /// <param name="status"></param>
        void ChangeStatus(TaskStatus status);

        /// <summary>
        /// Обновить информацию по задаче
        /// </summary>
        /// <param name="status"></param>
        void UpdateData(string name, string description, int responsibleManagerId);
    }
}
