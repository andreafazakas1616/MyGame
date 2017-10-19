using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.DAL.Interfaces
{
    public interface IUserItemsRepository
    {
        List<UserItem> GetAllItems(string userAspId);
    }
}
