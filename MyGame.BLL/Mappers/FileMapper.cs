using MyGame.DAL;
using MyGame.Infrastructure.Models;
using System.Collections.Generic;

namespace MyGame.BLL.Mappers
{
    public class FileMapper
    {
        public static List<FileModel> ConvertToModelList(List<File> entityList)
        {
            List<FileModel> modelList = new List<FileModel>();
            entityList.ForEach(s => modelList.Add(new FileModel { Id=s.id, Name=s.FileName}));
            return modelList;
        }

        public static FileModel GetModel(File entity)
        {
            FileModel model = new FileModel();
            model.Id = entity.id;
            model.Name = entity.FileName;
            return model;
        }

        public static File GetEntity(FileModel model)
        {
            File entity = new File();
            entity.FileName = model.Name;
            return entity;
        }
    }
}
