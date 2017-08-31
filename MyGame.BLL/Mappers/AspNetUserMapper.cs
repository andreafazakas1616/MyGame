using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;

namespace MyGame.BLL.Managers
{
    public class AspNetUserMapper
    {
        public static AspNetUserModel ConvertToModel(AspNetUser classEntity)
        {
            var aspModel = new AspNetUserModel();

            aspModel.Id = classEntity.Id;
            aspModel.Email = classEntity.Email;
            aspModel.EmailConfirmed = classEntity.EmailConfirmed;
            aspModel.LockoutDateUtc = classEntity.LockoutEndDateUtc ?? DateTime.Now;
            aspModel.LockoutEnabled = classEntity.LockoutEnabled;
            aspModel.PasswordHash = classEntity.PasswordHash;
            aspModel.PhoneNumber = classEntity.PhoneNumber;
            aspModel.PhoneNumberConfirmed = classEntity.PhoneNumberConfirmed;
            aspModel.SecurityStamp = classEntity.SecurityStamp;
            aspModel.TwoFactorEnabled = classEntity.TwoFactorEnabled;
            aspModel.UserName = classEntity.UserName;
            

            return aspModel;
        }
    }
}