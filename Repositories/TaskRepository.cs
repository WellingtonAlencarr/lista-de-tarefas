using Lista_de_Tarefas.Data;
using Lista_de_Tarefas.Models;
using Lista_de_Tarefas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Lista_de_Tarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext dataContext) 
        {
            _context = dataContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _context.TB_TASK
                    .Include(x => x.User)
                    .ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {

            return await _context.TB_TASK
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            await _context.TB_TASK.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não encontrado no banco de dados.");
            }

            taskById.Title = task.Title;
            taskById.Description = task.Description;
            taskById.CreateDate = task.CreateDate;
            taskById.ExpirationDate = task.ExpirationDate;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _context.TB_TASK.Update(taskById);
            await _context.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não encontrado no banco de dados.");
            }

            _context.TB_TASK.Remove(taskById);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
