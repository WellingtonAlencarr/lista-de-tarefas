using Lista_de_Tarefas.Data;
using Lista_de_Tarefas.Data.Map;
using Lista_de_Tarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;


namespace Lista_de_Tarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskModel newTask)
        {
            try
            {
                await _context.TB_TASK.AddAsync(newTask);
                await _context.SaveChangesAsync();

                return Ok(newTask.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            try
            {
                List<TaskModel> lista = await _context.TB_TASK.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                TaskModel p = await _context.TB_TASK
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                
                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskModel task)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async IActionResult DeleteTask(int id)
        {
            try
            {
                TaskMap? tkRemove = await _context.TB_TASK
                    .FirstOrDefaultAsync(phBusca => phBusca.);
            }
            
        }


    }
}
