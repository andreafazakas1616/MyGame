using MyGame.BLL.Mappers;
using MyGame.DAL;
using MyGame.DAL.Interfaces;
using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Managers
{
    public class UsersManagerBLL
    {
        #region ATTRIBUTE
        private readonly UsersRepository _usersRepository=null;
        private readonly IUsersRepository _repo; 
        #endregion ATTRIBUTE

        #region CONSTRUCTOR
        public UsersManagerBLL(UsersRepository usersRepository, IUsersRepository repo)

        {
            _usersRepository = usersRepository;
            _repo = repo;
        }
        #endregion CONSTRUCTOR

        #region public methods
        public UsersModel GetModel(int id)
        {
            var userModel = new UsersModel();
            var modelEntity = _usersRepository.GetById(id);
            userModel = UsersMapper.ConvertToModel(modelEntity);
            return userModel;

        }

        public UsersModel GetModel(string id)
        {
            var userModel = new UsersModel();
            var modelEntity = _usersRepository.GetById(id);
            userModel = UsersMapper.ConvertToModel(modelEntity);
            return userModel;

        }
        #endregion public methods


    }
}
