using MyGame.Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MyGame.DAL.Repository
{
    public class ClassRepository : IRepository<Class>
    {
        #region Attributes
        private readonly MyGameEntities _context = null;
        #endregion Attributes

        #region constructor
        public ClassRepository(MyGameEntities context)
        {
            _context = context;
        }
        #endregion constructor

#region CRUD

        public bool Delete(Class entity)
        {
            _context.Classes.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Class> GetAll()
        {
            return _context.Classes.ToList();
        }

        public Class GetById(int id)
        {
            return _context.Classes.Where(c => c.ID == id).FirstOrDefault();

        }

        public int Insert(Class entity)
        {
            _context.Classes.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
            return entity.ID;
        }

        public void Update(Class entity)
        {
            _context.Classes.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            
        }
#endregion CRUD

    }
}
