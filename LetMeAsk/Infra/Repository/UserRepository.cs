using Letmeask.DataContext;
using Letmeask.Entities;
using Letmeask.Models;
using Letmeask.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Letmeask.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.Where(user => user.Email == email).Select(user => user).FirstOrDefaultAsync();

        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.Users.Where(user => user.Id == id).Select(user => user).FirstOrDefaultAsync();
        }

        public async Task<UserModel> UserCreate(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<UserModel> UserUpdate(User user, Guid id)
        {
            var userExist = GetByEmail(user.Email);

            if (userExist != null)
            {
                throw new Exception("Já existe um usuário com esse email tente novamente usando outro");
            }

            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }

        public void UserDelete(Guid id)
        {
            _context.Users.Where(user => user.Id == id).Select(user => user).FirstOrDefault();
        }

    }
}
