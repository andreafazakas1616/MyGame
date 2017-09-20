using MyGame.BLL.Mappers;
using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.BLL.Managers
{
    public class ClassManagerBLL
    {
        #region Attributes
        private readonly ClassRepository _classRepository = null;
        #endregion Attributes

        #region Constructor 
        public ClassManagerBLL(ClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        #endregion Constructor

        #region public methods
        public ClassModel GetModel(int id)
        {
            var modelEntity = _classRepository.GetById(id);
            var classModel = ClassMapper.ConvertToModel(modelEntity);
            return classModel;
        }

        public List<ClassModel> GetClasses()
        {
            List<ClassModel> classModelList = new List<ClassModel>();
            var classes = _classRepository.GetAll();
            classModelList = ClassMapper.ConvertToModel(classes);
            return classModelList;
        }
        #endregion public methods
    }
}
