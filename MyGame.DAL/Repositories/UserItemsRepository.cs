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
            var query = from c in _context.UserItems
                        where c.UserId==userAspId
                        select c;

             List<UserItem> list_item = query.ToList<UserItem>();

            return list_item;
        }
    }
}
