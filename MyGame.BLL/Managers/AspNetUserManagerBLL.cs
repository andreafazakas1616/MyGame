using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;

namespace MyGame.BLL.Managers
{
    public class AspNetUserManagerBLL
    {
        #region Attributes
        private readonly UsersRepository _usersRepository = null;
        #endregion Attributes

        #region Constructor 
        public AspNetUserManagerBLL(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        #endregion Constructor

        #region public methods
        public AspNetUserModel GetModel(string id)
        {
            var modelEntity = _usersRepository.GetById(id);
            var aspNetUserModel = AspNetUserMapper.ConvertToModel(modelEntity.AspNetUser);
            return aspNetUserModel;
        }
        #endregion public methods
    }
}
