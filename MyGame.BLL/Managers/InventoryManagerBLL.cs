using MyGame.BLL.Mappers;
using MyGame.DAL;
using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Managers
{
    public class InventoryManagerBLL
    {
        #region ATTRIBUTES
        private readonly InventoryRepository _inventoryRepository;
        #endregion ATTRIBUTES

        #region CONSTRUCTOR
        public InventoryManagerBLL(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion CONSTRUCTOR

        #region public methods
        public InventoryModel GetModel(int id)
        {
           // var inventoryModel = new InventoryModel();
            var modelEntity = _inventoryRepository.GetById(id);
            var inventoryModel =InventoryMapper.ConvertToModel(modelEntity);
            return inventoryModel;
        }

        public void AddItemModel(int itemId, int userId)
        {
            var newItem = new Inventory { ID_Item = itemId, ID_User = userId };
            _inventoryRepository.AddItem(newItem);

        }
        #endregion public methods

      
    }
}
