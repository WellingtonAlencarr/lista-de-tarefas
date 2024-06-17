using Lista_de_Tarefas.Models;

namespace Lista_de_Tarefas.Repositories.Interfaces
{
    public class ILoginRepository
    {
        Task<LoginModel> AddLogin(LoginModel login);
        Task<LoginModel> UpdateLogin(UserModel user, int id, LoginModel login);
        Task<bool> Delete(int id);
    }
}
