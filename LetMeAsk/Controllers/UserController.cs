using Letmeask.Model;
using Letmeask.Repository;
using Letmeask.Repository.Interface;
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
        public IEnumerable<User> Get()
        {
            return this._userRepository.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return this._userRepository.GetById(id);
        }

        // GET api/<UserController>/teste@teste.com
        [HttpGet("{email}")]
        public User GetByEmail(string email)
        {
            return this._userRepository.GetByEmail(email);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            try
            {
                this._userRepository.UserCreate(user);
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
            this._userRepository.UserDelete(id);
        }
    }
}
