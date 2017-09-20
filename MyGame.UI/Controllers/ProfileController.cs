using Microsoft.AspNet.Identity;
using MyGame.BLL.Managers;
using MyGame.BLL.Mappers;
using MyGame.DAL;
using MyGame.DAL.Interfaces;
using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;
using MyGame.UI.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyGame.UI.Controllers
{
    public class ProfileController : Controller
    {

        private readonly MyGameEntities _context;
        private readonly IUsersRepository _userRepository;
        private readonly ClassRepository _classRepository;
        private readonly ClassManagerBLL _classManager;
        private readonly UsersManagerBLL _userManager;

        public ProfileController(IUsersRepository usersRepository, ClassRepository classRepository, MyGameEntities context, ClassManagerBLL classManager, UsersManagerBLL userManager)
        {
            _userManager = userManager;
            _classManager = classManager;
            _userRepository = usersRepository;
            _classRepository = classRepository;
            _context = context;
        }



        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        //get ChooseClass
        public ActionResult InitialScreen()
        {
            UserViewModel model = new UserViewModel();
            var classList = _classManager.GetClasses();
            model.ClassList = new List<SelectListItem>();

            model.ClassList = ConvertToSelectList(classList);

            return View(model);
        }



        //post ChooseClass
        [HttpPost]
        public ActionResult InitialScreen(UserViewModel userViewModel)
        {
            ViewBag.Message = "Create Your Character";

            var classList = _classManager.GetClasses();
            userViewModel.ClassList = new List<SelectListItem>();

            userViewModel.ClassList = ConvertToSelectList(classList);

            var userId = User.Identity.GetUserId();

            Class classEntity = _classRepository.GetById(userViewModel.ClassId);

            if (_userRepository.UserNameExists(userViewModel.Name))
            {
                ModelState.AddModelError("Name", "Username is already in use. Please choose another one.");
                return View(userViewModel);
            }

            var usersModel = ConvertToBLL(userViewModel);
            User user = UsersMapper.ConvertToEntity(usersModel);

            user.ASP_ID = userId;
            user.Level = 1;
            user.Name = usersModel.Name;
            user.Class_ID = classEntity.ID;
            user.Armor = classEntity.Base_defense;
            user.Attack = classEntity.Base_attack;
            user.HP = classEntity.Base_HP;
            user.XP_needed = 50;
           
            _userRepository.Insert(user);
            _context.SaveChanges();
            return RedirectToAction("PlayerView", "Profile", null);
        }

        [HttpGet]
        public ActionResult PlayerView(string id)
        {
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            
            User user = _userRepository.GetById(id);
            UsersModel userModel = UsersMapper.ConvertToModel(user);
            UserViewModel userViewModel = ConvertToViewModel(userModel);

            Class classEntity = _classRepository.GetById(userViewModel.ClassId);
            ClassModel classModel = ClassMapper.ConvertToModel(classEntity);
            ClassViewModel classViewModel = ConvertToViewModel(classModel);
            userViewModel.ClassId = classViewModel.ID;
            userViewModel.ClassName = classViewModel.Name;

            return View(userViewModel);

        }

        [HttpPost]
        public ActionResult PlayerView(UserViewModel userViewModel)
        {

            if (userViewModel.AspId == null)
            {
                userViewModel.AspId= User.Identity.GetUserId();
            }

            if(userViewModel.UploadedImage==null)
            {
                return RedirectToAction("PlayerView", "Profile");
            }
            
            byte[] uploadedFile = new byte[userViewModel.UploadedImage.InputStream.Length];
            userViewModel.UploadedImage.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
            userViewModel.Image = Convert.ToBase64String(uploadedFile);

             UsersModel userModel = ConvertToBLL(userViewModel);
             User user = UsersMapper.ConvertToEntity(userModel);

           


            _userRepository.UpdateUserPicture(user);
            _context.SaveChanges();

            return View(userViewModel);
        }
        /// <summary>
        ///  This is the first function that executes after login.
        ///  It checks to see if there is an entry in the User table with the email used for the login
        ///  If there is, then redirect to profile page
        ///  Else, let the player pick his class and username, and create a User based on that
        /// </summary>
        /// <param name="email">The email used for logging in</param>
        /// <returns></returns>
        public ActionResult CheckIfUserHasClass(string email)
        {
            if (_userRepository.CheckIfUserExists(email))
            {
                return RedirectToAction("PlayerView", "Profile", null);
            }
            else
            {
                return RedirectToAction("InitialScreen", "Profile", null);
            }
        }



        private static List<SelectListItem> ConvertToSelectList(List<ClassModel> classModelList)
        {
            List<SelectListItem> classModelSelectList = new List<SelectListItem>();
            classModelSelectList.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "Select class" });
            classModelList.ForEach(s => classModelSelectList.Add(new SelectListItem { Text = s.Name, Value = s.ID.ToString() }));
            return classModelSelectList;
        }

        private static UsersModel ConvertToBLL(UserViewModel userViewModel)
        {
            UsersModel userModel = new UsersModel();
            userModel.ID = userViewModel.Id;
            userModel.Class_ID = userViewModel.ClassId;
            userModel.Name = userViewModel.Name;
            userModel.Image = userViewModel.Image;
            userModel.Level = userViewModel.Level;
            userModel.Armor = userViewModel.Armor;
            userModel.Asp_Id = userViewModel.AspId;
            userModel.Attack = userViewModel.Attack;
            userModel.ErrorMessage = userViewModel.ErrorMessage;
            userModel.XP = userViewModel.Xp;
            userModel.XP_needed = userViewModel.Xp_needed;
            return userModel;
        }

        private static UserViewModel ConvertToViewModel(UsersModel userModel)
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.Id = userModel.ID;
            userViewModel.ClassId = userModel.Class_ID;
            userViewModel.Name = userModel.Name;
            userViewModel.Image = userModel.Image;
            userViewModel.Level = userModel.Level;
            userViewModel.Armor = userModel.Armor;
            userViewModel.AspId = userModel.Asp_Id;
            userViewModel.Attack = userModel.Attack;
            userViewModel.Xp_needed = userModel.XP_needed;
            return userViewModel;
        }

        private static ClassViewModel ConvertToViewModel(ClassModel classModel)
        {
            ClassViewModel classViewModel = new ClassViewModel();
            classViewModel.ID= classModel.ID ;
            classViewModel.Name= classModel.Name ;
            classViewModel.Base_Attack= classModel.Base_Attack ;
            classViewModel.Base_Defense= classModel.Base_Defense ;
            classViewModel.Base_HP = classModel.Base_HP;
            return classViewModel;

        }
    }
}