//using MyGame.DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyGame.DAL.Repositories
//{
//    public class UserCoordsRepository:IUserCoords
//    {
//        private readonly MyGameEntities _context=null;

//        public UserCoordsRepository(MyGameEntities context)
//        {
//            _context = context;
//        }

//        

//        //public UserCoord GetCoordsById(string userId)
//        //{
//        //    var coords=_context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
//        //    return coords;
//        //}

//        //public void MoveUp(string userId)
//        //{
//        //    var coords = _context.UserCoords.Where(u => u.UserId == userId).FirstOrDefault();
//        //    coords.CoordY += 1;
//        //    _context.SaveChanges();
//        //}
//    }
//}
