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
    public class FileManagerBLL
    {
        private readonly FileRepository _fileRepository;
        public FileManagerBLL(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public List<FileModel> GetAllFiles()
        {
            List<File> entityList = _fileRepository.GetAll();
            List<FileModel> modelList = Mappers.FileMapper.ConvertToModelList(entityList);
            return modelList;
        }

        public void AddFile(FileModel model)
        {
            File entity = Mappers.FileMapper.GetEntity(model);
            _fileRepository.Add(entity.FileName);
            //hi
            //bye
        }

        
    }
}
