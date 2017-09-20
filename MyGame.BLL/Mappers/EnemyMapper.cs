using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Mappers
{
    public class EnemyMapper
    {
        public static EnemyModel ConvertToModel(Enemy enemyEntity)
        {
            var enemyModel = new EnemyModel();
            
            enemyModel.ID = enemyEntity.ID;
            enemyModel.Name = enemyEntity.Name;
            enemyModel.Attack = enemyEntity.Attack??0;
            enemyModel.Defense = enemyEntity.Defense??0;
            enemyModel.HP = enemyEntity.HP??0;
            enemyModel.XP_given = enemyEntity.XP_given ?? 0;

            return enemyModel;

        }

        public static Enemy ConvertToEntity(EnemyModel model)
        {
            var entity = new Enemy();
            entity.ID = model.ID;
            entity.Name = model.Name;
            entity.Attack = model.Attack;
            entity.Defense = model.Defense;
            entity.HP = model.HP;
            entity.XP_given = model.XP_given;

            return entity;
        }
    }
}
