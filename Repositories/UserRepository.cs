using Lista_de_Tarefas.Data;
using Lista_de_Tarefas.Models;
using Lista_de_Tarefas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Lista_de_Tarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext dataContext) 
        {
            _context = dataContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.TB_USER.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _context.TB_USER.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _context.TB_USER.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não encontrado no banco de dados.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _context.TB_USER.Update(userById);
            await _context.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não encontrado no banco de dados.");
            }

            _context.TB_USER.Remove(userById);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
