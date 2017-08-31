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
    public class ItemsManagerBLL
    {
        #region ATTRIBUTES  
        private readonly ItemsRepository _itemsRepository=null;
        #endregion ATTRIBUTES

        #region CONSTRUCTOR 
        public ItemsManagerBLL(ItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        #endregion CONSTRUCTOR

        #region public methods

        public ItemsModel GetModel(int id)
        {
            var itemsModel = new ItemsModel();
            var modelEntity = _itemsRepository.GetById(id);
            itemsModel = ItemsMapper.ConvertToModel(modelEntity);
            return itemsModel;
        }

        #endregion public methods

     

    }
}
