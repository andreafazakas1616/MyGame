using MyGame.DAL;
using MyGame.DAL.Repositories;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Managers
{
    public class UserItemManagerBLL
    {
        private readonly UserItemsRepository _userItemsRepository = null;
        public UserItemManagerBLL(UserItemsRepository userItemsRepository)
        {
            _userItemsRepository = userItemsRepository;
        }

        public List<UserItemModel> GetItems(string aspId)
        {
            
            List<UserItem> entityList=_userItemsRepository.GetAllItems(aspId);
            List<UserItemModel> modelList = Mappers.UserItemMapper.GetModelList(entityList);
            return modelList;

        }
    }
}
