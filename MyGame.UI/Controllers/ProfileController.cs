using Microsoft.AspNet.Identity;
using MyGame.BLL.Mappers;
using MyGame.DAL;
using MyGame.DAL.Interfaces;
using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;
using MyGame.UI.Models.Users;
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

        public ProfileController(IUsersRepository usersRepository, ClassRepository classRepository, MyGameEntities context)
        {
            _userRepository = usersRepository;
            _classRepository = classRepository;
            _context = context;
        }

      

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int? id)
        {
            return View();
        }

        

        [HttpGet]
        //get ChooseClass
        public ActionResult InitialScreen()
        {
            return View();
        }

       
       
        //post ChooseClass
        [HttpPost]
        public ActionResult InitialScreen(UsersModel usersModel)
        {
            ViewBag.Message = "Create Your Character";
                   
                        

            var userId = User.Identity.GetUserId();
            
            Class classEntity = _classRepository.GetById(usersModel.Class_ID);

            


            if (_userRepository.UserNameExists(usersModel.Name))
            {
                usersModel.ErrorMessage = "Username Already Exists";
                return View(usersModel);
            }
            
            
            User user = UsersMapper.ConvertToEntity(usersModel);

            user.ASP_ID = userId;
            user.Name = usersModel.Name;
            user.Class_ID = classEntity.ID;
            user.Armor = classEntity.Base_defense;
            user.Attack = classEntity.Base_attack;
            user.HP = classEntity.Base_HP;
            
            

            _userRepository.Insert(user);
            _context.SaveChanges();
            return RedirectToAction("View", "Profile", null);
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
                return RedirectToAction("View", "Profile", null);
            }
            else
            {
                return RedirectToAction("InitialScreen", "Profile", null);
            }
        }
    }
}