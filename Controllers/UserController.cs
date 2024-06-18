using Lista_de_Tarefas.Models;
using Lista_de_Tarefas.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Lista_de_Tarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            UserModel user = await _userRepository.RegisterUser(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool delete = await _userRepository.Delete(id);

            return Ok(delete);
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(UserModel credentials)
        {
            UserModel user = await _userRepository.Auth(credentials);

            return Ok(Auth);
        }
    }
}
