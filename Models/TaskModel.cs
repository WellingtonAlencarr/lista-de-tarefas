using Lista_de_Tarefas.Models.Enums;
using System.Data.SqlTypes;

namespace Lista_de_Tarefas.Models
{
    public class TaskModel
    {
        private static int _nextId = 1;

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string ExpirationDate { get; set; }
        public StatusTask Status { get; set; }

        public TaskModel()
        {
            Id = _nextId++;
        }
    }
}
