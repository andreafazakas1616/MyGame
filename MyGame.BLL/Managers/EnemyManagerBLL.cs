using MyGame.BLL.Mappers;
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
        public EnemyModel GetModel(int id)
        {
            var modelEntity = _enemyRepository.GetById(id);
            var enemyModel = EnemyMapper.ConvertToModel(modelEntity);
            return enemyModel;
        }
#endregion public methods
    }
}
