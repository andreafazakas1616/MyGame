
using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Mappers
{
    public class ClassMapper
    {
        public static ClassModel ConvertToModel(Class classEntity)
        {
            var classModel = new ClassModel();

            classModel.ID = classEntity.ID;
            classModel.Name = classEntity.Name;
            classModel.Base_Attack = classEntity.Base_attack ?? 0;
            classModel.Base_Defense = classEntity.Base_defense ?? 0;
            classModel.Base_HP = classEntity.Base_HP ?? 0;

            return classModel;
        }



        public static Class ConvertToEntity(ClassModel classModel)
        {
            var classEntity = new Class();
            classEntity.ID = classModel.ID;
            classEntity.Name = classModel.Name;
            classEntity.Base_attack = classModel.Base_Attack;
            classEntity.Base_defense = classModel.Base_Defense;
            classEntity.Base_HP = classModel.Base_HP;

            return classEntity;

        }

        public static List<ClassModel> ConvertToModel(List<Class> classList)
        {
            List<ClassModel> classModelList = new List<ClassModel>();

            classList.ForEach(s => classModelList.Add(new ClassModel {ID=s.ID, Name=s.Name }));

            return classModelList;
        }

    }
}
