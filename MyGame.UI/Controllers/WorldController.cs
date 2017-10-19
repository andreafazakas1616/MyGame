using Microsoft.AspNet.Identity;
using MyGame.DAL;
using MyGame.DAL.Repository;
using MyGame.UI.Models;
using MyGame.UI.Models.Users;
using System.Web.Mvc;

namespace MyGame.UI.Controllers
{
    public class WorldController : Controller
    {
        // GET: World

        private readonly UsersRepository _userRepository = null;
        private readonly EnemyRepository _enemyRepository = null;

        public WorldController(UsersRepository userRepository, EnemyRepository enemyRepository)
        {
            _userRepository = userRepository;
            _enemyRepository = enemyRepository;
        }
        public ActionResult Index(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            model.AspId = userId;
            
            UserCoord coords = new UserCoord();
            coords = _userRepository.GetCoordsById(userId);

            model.CoordX = coords.CoordX ?? 0;
            model.CoordY = coords.CoordY ?? 0;

            return View(model);
        }

        public ActionResult GetCoords(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            UserCoord coords = new UserCoord();
            coords = _userRepository.GetCoordsById(userId);
            
            model.CoordX = coords.CoordX??0;
            model.CoordY = coords.CoordY ?? 0;

            return PartialView("_GetCoords", model);
        }

        public ActionResult MoveUp(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            UserCoord userCoord= _userRepository.MoveUp(userId);
            model.CoordX = userCoord.CoordX??0;
            model.CoordY = userCoord.CoordY ?? 0;
            return PartialView("_GetCoords", model);
        }

        public ActionResult MoveDown(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            UserCoord userCoord = _userRepository.MoveDown(userId);
            model.CoordX = userCoord.CoordX ?? 0;
            model.CoordY = userCoord.CoordY ?? 0;
            return PartialView("_GetCoords", model);
        }

        public ActionResult MoveLeft(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            UserCoord userCoord = _userRepository.MoveLeft(userId);
            model.CoordX = userCoord.CoordX ?? 0;
            model.CoordY = userCoord.CoordY ?? 0;
            return PartialView("_GetCoords", model);
        }

        public ActionResult MoveRight(UserViewModel model)
        {
            var userId = User.Identity.GetUserId();
            UserCoord userCoord = _userRepository.MoveRight(userId);
            model.CoordX = userCoord.CoordX ?? 0;
            model.CoordY = userCoord.CoordY ?? 0;
            return PartialView("_GetCoords", model);
        }

        public ActionResult GetActions()
        {
            var userId = User.Identity.GetUserId();
            UserCoord userCoord = _userRepository.GetCoordsById(userId);

            var model = new ActionsViewModel();
            
            var mobList = _enemyRepository.GetEnemiesByCoordinate(userCoord.CoordX??0, userCoord.CoordY??0);
            foreach (var mob in mobList)
            {
                model.ActionList.Add(new ActionRowViewModel { Name = mob.Name, Link = "/Fight/FightMobById?enemyId="+ mob.ID });
               
            }
            model.ActionList.Add(new ActionRowViewModel {Name="Shop", Link="/Shop/Shop" });

            return PartialView("_Actions", model);
        }

        public ActionResult GetMenu()
        {
            var aspId = User.Identity.GetUserId();
            var user = _userRepository.GetById(aspId);

            var model = new OptionsViewModel();

            return PartialView("_Menu", model);
        }

        public ActionResult Rest()
        {
            var aspId = User.Identity.GetUserId();
            var user = _userRepository.GetById(aspId);
            
            user.HP = 100;
            _userRepository.Update(user);

            return RedirectToAction("Index");
        }
    }
}