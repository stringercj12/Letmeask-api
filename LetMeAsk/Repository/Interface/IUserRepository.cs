using Letmeask.Model;

namespace Letmeask.Repository.Interface
{
    public interface IUserRepository
    {
        public void UserCreate(User user);
        public void UserUpdate(User user, Guid id);
        public void UserDelete(Guid id);
        public IEnumerable<User> GetAll();
        public User GetById(Guid id);
        public User GetByEmail(string email);
    }
}
