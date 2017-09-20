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
    public class EnemyManagerBLL
    {
        #region Attributes
        private readonly EnemyRepository _enemyRepository = null;
        #endregion Attributes

        #region Constructor
        public EnemyManagerBLL(EnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }
        #endregion Constructor

#region public methods
        
        public EnemyModel GetEnemyById(int enemyId)
        {
            var modelEntity = _enemyRepository.GetById(enemyId);
            var enemyModel = EnemyMapper.ConvertToModel(modelEntity);
            return enemyModel;
        }

        public EnemyModel GetRandomEnemyModel()
        {
            EnemyModel model = new EnemyModel();
            List<Enemy> enemyList = new List<Enemy>();
            enemyList = _enemyRepository.GetAll();
            Random rnd = new Random();
            var randomEnemy = enemyList.OrderBy(enemy => rnd.Next()).Take(1).First();
            model = EnemyMapper.ConvertToModel(randomEnemy);
            return model;
        }
        #endregion public methods
    }
}
