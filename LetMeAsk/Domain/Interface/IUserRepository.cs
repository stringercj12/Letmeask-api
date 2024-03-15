using Letmeask.Entities;
using Letmeask.Models;

namespace Letmeask.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<UserModel> UserCreate(UserModel user);
        public void UserUpdate(User user, Guid id);
        public void UserDelete(Guid id);
        public Task<IEnumerable<User>> GetAll();
        public Task<UserModel> GetById(Guid id);
        public Task<User> GetByEmail(string email);
    }
}
