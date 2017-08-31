using MyGame.DAL;
using MyGame.Infrastructure.Models;

namespace MyGame.BLL.Mappers
{
    public class UsersMapper
    {
        public static UsersModel ConvertToModel(User userEntity)
        {
            var userModel = new UsersModel();

            userModel.ID = userEntity.ID;
            userModel.Name = userEntity.Name;
            userModel.Level = userEntity.Level ?? 0;
            userModel.Class_ID = userEntity.Class_ID;
            userModel.XP = userEntity.XP;
            userModel.XP_needed = userEntity.XP_needed??0;
            userModel.Asp_Id = userEntity.ASP_ID;
            userModel.Image = userEntity.Image;
            userModel.Armor = userEntity.Armor ?? 0;
            userModel.Attack = userEntity.Attack ?? 0;

            return userModel;
        }
        public static User ConvertToEntity(UsersModel userEntity)
        {
            var userModel = new User();

            userModel.ID = userEntity.ID;
            userModel.Name = userEntity.Name;
            userModel.Level = userEntity.Level;
            userModel.Class_ID = userEntity.Class_ID;
            userModel.XP = userEntity.XP;
            userModel.XP_needed = userEntity.XP_needed;
            userModel.ASP_ID = userEntity.Asp_Id;
            userModel.Image = userEntity.Image;
            userModel.Armor = userEntity.Armor;
            userModel.Attack = userEntity.Attack;
            return userModel;
        }
    }

}
