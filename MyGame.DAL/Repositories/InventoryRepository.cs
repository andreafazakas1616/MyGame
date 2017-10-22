using MyGame.Repository.Repository;
using System.Collections.Generic;
using System.Linq;


namespace MyGame.DAL.Repository
{
    public class InventoryRepository:IRepository<Inventory>
    {
        #region ATTRIBUTES
        private readonly MyGameEntities _context=null;
        private List<Inventory> list;
        #endregion ATTRIBUTES

        #region CONSTRUCTOR 
        public InventoryRepository(MyGameEntities context)
        {
             list= new List<Inventory>();
            _context = context;
        }


        #endregion CONSTRUCTOR

        #region CRUD
        public bool Delete(Inventory entity)
        {
            _context.Inventories.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Inventory> GetAll()
        {
            return _context.Inventories.ToList();
        }

        public List<GetSth_Result2> GetAllById(int userId)
        {
            return _context.GetSth(userId).ToList();
        }

        public Inventory GetById(int id)
        {
            return _context.Inventories.Where(i => i.ID == id).FirstOrDefault();
        }

        public int Insert(Inventory entity)
        {
            _context.Inventories.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();

            return entity.ID;
        }

        public void Update(Inventory entity)
        {
            _context.Inventories.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddItem(Inventory entity)
        {
            
            _context.Inventories.Add(entity);
            _context.SaveChanges();
            return entity.ID;            
        }
#endregion CRUD



    }
}
