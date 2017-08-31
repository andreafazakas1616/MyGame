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

            return enemyModel;

        }
    }
}
