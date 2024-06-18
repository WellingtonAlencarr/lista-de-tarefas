using Lista_de_Tarefas.Data;
using Lista_de_Tarefas.Models;
using Lista_de_Tarefas.Repositories.Interfaces;
using Lista_de_Tarefas.Utils;
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

        public async Task<UserModel> RegisterUser(UserModel user)
        {
            if (await ExistingUser(user.Username))
                throw new System.Exception("Nome de usuário já existe");

            Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

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

        public async Task<bool> ExistingUser(string username)
        {
            if(await _context.TB_USER.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<UserModel> Auth(UserModel credentials)
        {
            UserModel? user = await _context.TB_USER
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credentials.Username.ToLower()));

            if (user == null)
            {
                throw new System.Exception("Usuário não encontrado.");
            }
            else if (!Criptografia
                .VerificarPasswordHash(credentials.PasswordString, user.PasswordHash, user.PasswordSalt))
            {
                throw new System.Exception("Senha incorreta.");
            }
            else
            {
                return user;
            }
        }
    }
}
