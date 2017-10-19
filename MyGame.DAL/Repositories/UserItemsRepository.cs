using MyGame.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyGame.DAL.Repositories
{
    public class UserItemsRepository:IUserItemsRepository
    {
        private readonly MyGameEntities _context = null;
        public UserItemsRepository(MyGameEntities context)
        {
            _context = context;
        }

        public List<UserItem> GetAllItems(string userAspId)
        {
            return _context.UserItems.Where(u => u.UserId == userAspId).ToList();
        }
    }
}
