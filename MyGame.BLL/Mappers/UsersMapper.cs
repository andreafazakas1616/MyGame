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
            userModel.HP = userEntity.Class.Base_HP??0;

            return userModel;
        }
        public static User ConvertToEntity(UsersModel userModel)
        {
            var userEntity = new User();

            userEntity.ID = userModel.ID;
            userEntity.Name=userModel.Name;
            userEntity.Level=userModel.Level;
            userEntity.Class_ID=userModel.Class_ID;
            userEntity.XP=userModel.XP;
            userEntity.XP_needed=userModel.XP_needed;
            userEntity.ASP_ID=userModel.Asp_Id;
            userEntity.Image=userModel.Image;
            userEntity.Armor=userModel.Armor;
            userEntity.Attack=userModel.Attack;
                
            return userEntity;
        }

        
    }

}
