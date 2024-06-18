using Lista_de_Tarefas.Models;

namespace Lista_de_Tarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(int id);
        Task<UserModel> RegisterUser(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
        Task<bool> ExistingUser(string username);
        Task<UserModel> Auth(UserModel credentials);

    }
}
