using Letmeask.DataContext;
using Letmeask.Model;
using Letmeask.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Letmeask.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context) {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return this._context.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            var user = this._context.Users.Where(user => user.Email == email).Select(user => user).FirstOrDefault();    

            if (user == null)
            {
                return null;
            }

            return user;

        }

        public User GetById(Guid id)
        {
            var user = this._context.Users.Where(user => user.Id == id).Select(user => user).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public void UserCreate(User user)
        {
            var userExist = GetByEmail(user.Email);

            if (userExist != null)
            {
                throw new Exception("Já existe um usuário com esse email tente novamente usando outro");
            }

            this._context.Users.Add(user);
            this._context.SaveChanges();

        }

        public void UserUpdate(User user, Guid id)
        {
            var userExist = GetByEmail(user.Email);

            if (userExist != null)
            {
                throw new Exception("Já existe um usuário com esse email tente novamente usando outro");
            }

            this._context.Users.Update(user);
            this._context.SaveChanges();
        }

        public void UserDelete(Guid id)
        {
            var user = this._context.Users.Where(user => user.Id == id).Select(user => user).FirstOrDefault();

            if (user != null)
            {
                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }
        }
    }
}
