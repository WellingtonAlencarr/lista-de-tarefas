using Lista_de_Tarefas.Models.Enums;
using System.Data.SqlTypes;

namespace Lista_de_Tarefas.Models
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string ExpirationDate { get; set; }
        public StatusTask Status { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }
}
