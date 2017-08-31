using System.Collections.Generic;

namespace MyGame.DAL.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(int id);
        User GetById(string id);
        List<User> GetAll();
        int Insert(User entity);
        void Update(User entity);
        bool Delete(User entity);
        bool CheckIfUserExists(string email);
        bool UserNameExists(string userName);
        
    }
}
