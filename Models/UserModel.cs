using System.Net.NetworkInformation;

namespace Lista_de_Tarefas.Models
{
    public class UserModel
    {
        public static int _nextId = 1;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public UserModel()
        {
            Id = _nextId++;
        }

    }
}
