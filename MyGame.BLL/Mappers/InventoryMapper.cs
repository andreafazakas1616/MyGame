using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Mappers
{
    public class InventoryMapper
    {
        public static InventoryModel ConvertToModel(Inventory inventoryEntity)
        {
            var inventoryModel = new InventoryModel();

            inventoryModel.ID = inventoryEntity.ID;
            inventoryModel.ID_Item = inventoryEntity.ID_Item ?? 0;
            inventoryModel.ID_User = inventoryEntity.ID_User ?? 0;

            return inventoryModel;

        }


    }
}
