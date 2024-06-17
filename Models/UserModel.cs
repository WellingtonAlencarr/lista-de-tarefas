using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Lista_de_Tarefas.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public UserModel(int id, string? name, string? email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public UserModel(string? name, string? email)
        {
            Name = name;
            Email = email;
        }

        public void UpdatePassword(byte[] PasswordHash, byte[] PasswordSalt) 
        {
            PasswordHash = PasswordHash;
            PasswordSalt = PasswordSalt;
        }

    }
}
