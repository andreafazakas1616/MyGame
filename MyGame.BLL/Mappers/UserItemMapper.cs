using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Mappers
{
    public class UserItemMapper
    {
        public static List<UserItemModel> GetModelList(List<UserItem> entityList)
        {
            List<UserItemModel> modelList = new List<UserItemModel>();

            entityList.ForEach(s => modelList.Add(new UserItemModel {Name=s.ItemName, Attack=s.ItemAttack??0, Defense=s.ItemDefense??0, HpRegen=s.HPregeneration??0 }));
            return modelList;
        }
    }
}
