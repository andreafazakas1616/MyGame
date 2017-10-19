using MyGame.DAL.Interfaces;
using MyGame.Repository.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

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
            var user = _context.Users.First(x => x.ASP_ID == entity.ASP_ID);

            if(user!=null)
            {
                user.ID = entity.ID;
                user.Armor = entity.Armor;
                user.ASP_ID = entity.ASP_ID;
                user.Attack = entity.Attack;
                user.Class_ID = entity.Class_ID;
                user.HP = entity.HP;
                user.Image = entity.Image;
                user.Inventories = entity.Inventories;
                user.Level = entity.Level;
                user.Name = entity.Name;
                user.XP = entity.XP;
                user.XP_needed = entity.XP_needed;
                _context.SaveChanges();
            }
        }

        public void IncrementExperience(int userId, int xp_given)
        {
            var user = _context.Users.Where(u => u.ID == userId).First();
            user.XP += xp_given;

            _context.SaveChanges();
        }

        public void UpdateUserPicture(User entity)
        {
            var user = _context.Users.First(x => x.ASP_ID == entity.ASP_ID);

            if (user != null)
            {
                user.Image = entity.Image;
                _context.SaveChanges();
            }
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
            return _context.Users.Any(u => u.Name == userName);
        }


        public UserCoord GetCoordsById(string userId)
        {
           
           UserCoord coords = _context.UserCoords.FirstOrDefault(u => u.UserId == userId);
            
            if(coords==null)
            {
                coords = new UserCoord(); 
                coords.UserId = userId;
                coords.CoordX = 1;
                coords.CoordY = 1;

                _context.UserCoords.Add(coords);
                _context.SaveChanges();
                return coords;
               
            }
            
            return coords;
        }

        public UserCoord MoveUp(string userId)
        {
            var coords = _context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
            if(coords.CoordY==0)
            {
                return coords;
            }
            coords.CoordY -= 1;
            _context.SaveChanges();
            return coords;
        }

        public UserCoord MoveDown(string userId)
        {
            var coords = _context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
            if (coords.CoordY == 49)
            {
                return coords;
            }
            coords.CoordY += 1;
            _context.SaveChanges();
            return coords;
        }

        public UserCoord MoveLeft(string userId)
        {
            var coords = _context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
            if (coords.CoordX == 0)
            {
                return coords;
            }
            coords.CoordX -= 1;
            _context.SaveChanges();
            return coords;
        }

        public UserCoord MoveRight(string userId)
        {
            var coords = _context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
            if (coords.CoordX == 49)
            {
                return coords;
            }
            coords.CoordX += 1;
            _context.SaveChanges();
            return coords;
        }

        public void IncrementLevelAndStats(int userId)
        {
            var user = _context.Users.Where(u => u.ID == userId).First();
            user.Level++;
            user.XP_needed = user.Level * 30;
            user.Armor += 4;
            user.Attack += 4;

            _context.SaveChanges();
        }

        public void PlayerLostABattle(int userId)
        {
            var user= _context.Users.Where(u => u.ID == userId).First();
            user.HP = 0;
            _context.SaveChanges();
        }

        #endregion CRUD 
    }
}
