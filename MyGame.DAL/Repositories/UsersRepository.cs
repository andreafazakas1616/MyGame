using MyGame.DAL.Interfaces;
using MyGame.Repository.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyGame.DAL.Repository
{
    public class UsersRepository : IRepository<User>, IUsersRepository
    {
        #region ATTRIBUTES
        private readonly MyGameEntities _context;
        #endregion ATTRIBUTES

        #region CONSTRUCTORS
        public UsersRepository(MyGameEntities context)
        {
            _context = context;
        }
#endregion CONSTRUCTORS

        #region CRUD
        public bool Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(u => u.ID == id).FirstOrDefault();
        }
        
        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
            return entity.ID;
        }

        public void Update(User entity)
        {
            _context.Users.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public User GetById(string id)
        {
            return _context.Users.Where(u => u.ASP_ID == id).Include(x => x.AspNetUser).FirstOrDefault();
        }

       
        public bool CheckIfUserExists(string userEmail)
        {
            return _context.Users.Include(x => x.AspNetUser).Where(u => u.AspNetUser.Email == userEmail).FirstOrDefault()!=null;
        }

        public bool UserNameExists(string userName)
        {
            var name = _context.Users.Select(u => u.Name).ToString();
            
           
            if(userName==name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
        #endregion CRUD 
    }
}
