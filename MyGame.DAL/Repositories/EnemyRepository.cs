using MyGame.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.DAL.Repository
{
    public class EnemyRepository:IRepository<Enemy>
    {
        #region ATTRIBUTES
        private readonly MyGameEntities _context = null;
        #endregion ATTRIBUTES

        #region CONSTRUCTORS
        public EnemyRepository(MyGameEntities context)
        {
            _context = context;
        }
        #endregion CONSTRUCTORS

        #region CRUD
        public bool Delete(Enemy entity)
        {
            _context.Enemies.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Enemy> GetAll()
        {
            return _context.Enemies.ToList();
        }

        public Enemy GetById(int id)
        {
            return _context.Enemies.Where(u => u.ID == id).FirstOrDefault();
        }

        public int Insert(Enemy entity)
        {
            _context.Enemies.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
            return entity.ID;
        }

        public void Update(Enemy entity)
        {
            _context.Enemies.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Enemy> GetEnemiesByCoordinate(int coordX, int coordY)
        {
            var enemiesAtCoords = _context.EnemyCoords.Where(x => x.CoordX == coordX && x.CoordY == coordY).Select(x => x.EnemyId);
            return _context.Enemies.Where(x => enemiesAtCoords.Contains(x.ID)).ToList();
        }
        #endregion CRUD
    }
}
