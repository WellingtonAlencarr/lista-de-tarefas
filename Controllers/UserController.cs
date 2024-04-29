using Lista_de_Tarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lista_de_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ActionResult<List<UserModel>> BuscarTodosUsuarios()
        {

            return Ok();
        }
    }
}
