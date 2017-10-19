using MyGame.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.DAL.Repository
{
    public class ItemsRepository:IRepository<Item>
    {
        #region ATTRIBUTES
        private readonly MyGameEntities _context = null;
        #endregion ATTRIBUTES

        #region CONSTRUCTOR
        public ItemsRepository(MyGameEntities context)
        {
            _context = context;
        }


        #endregion CONSTRUCTOR

        #region CRUD
        public bool Delete(Item entity)
        {
            _context.Items.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetById(int id)
        {
            return _context.Items.Where(t => t.ID == id).FirstOrDefault();
        }

        public int Insert(Item entity)
        {
            _context.Items.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
            return entity.ID;
        }

        public void Update(Item entity)
        {
            _context.Items.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }


        
#endregion CRUD





    }
}
