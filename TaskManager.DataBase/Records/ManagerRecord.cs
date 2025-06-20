
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Database.Records
{
    /// <summary>
    /// Список менеджеров, которые выполняют задачи
    /// </summary>
    public class ManagerRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
