using MyGame.DAL;
using MyGame.DAL.Repository;
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
        private readonly ItemsRepository _repository = null;
        public ItemsMapper(ItemsRepository repository)
        {
            _repository = repository;
        }
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

        public static List<ItemsModel> ConvertToModelList(List<Item> entityList)
        {
            List<ItemsModel> modelList = new List<ItemsModel>();
            entityList.ForEach(s => modelList.Add(new ItemsModel { ID = s.ID, Item = s.Item1, Attack = s.Attack ?? 0, Defense = s.Defense ?? 0, HPregeneration = s.HPregeneration ?? 0 }));
            return modelList;
        }
    }
}
