using Letmeask.Entities;
using Letmeask.Models;
using Letmeask.Repository;
using Letmeask.Repository.Interface;
using Letmeask.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Letmeask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAll();


            if (users != null)
            {
                return Ok(users);
            }


            return NotFound("Não encontrado");
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user != null)
            {
                return Ok(user);
            }


            return NotFound("Não encontrado");
        }

        // GET api/<UserController>/teste@teste.com
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                return NotFound("Não encontrado");
            }


            return Ok(UserViewModel.Mapear(user));
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(UserModel user)
        {

            var userExist = await GetByEmail(user.Email);

            if (userExist != null)
            {
                throw new Exception("Já existe um usuário com esse email tente novamente usando outro");
            }



            try
            {
                _userRepository.UserCreate(user);
            }
            catch (Exception)
            {
                NotFound();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            try
            {
                this._userRepository.UserUpdate(user, id);
            }
            catch (Exception)
            {
                NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
            }

           _userRepository.UserDelete(id);
        }
    }
}
