using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Mappers
{
    public class ItemsMapper
    {
        public static ItemsModel ConvertToModel(Item itemEntity)
        {
            var itemModel = new ItemsModel();
            itemModel.ID = itemEntity.ID;
            itemModel.Item = itemEntity.Item1;
            itemModel.Attack = itemEntity.Attack ?? 0;
            itemModel.Defense = itemEntity.Defense ?? 0;
            itemModel.HPregeneration = itemEntity.HPregeneration ?? 0;

            return itemModel;
        }
    }
}
