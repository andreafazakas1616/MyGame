using Microsoft.AspNet.Identity;
using MyGame.BLL.Managers;
using MyGame.Infrastructure.Models;
using MyGame.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGame.UI.Controllers
{
    public class FightController : Controller
    {
        private readonly FightManagerBLL _fightManager = null;
        private readonly UsersManagerBLL _userManager = null;

        public FightController(FightManagerBLL fightManager, UsersManagerBLL userManager)
        {
            _fightManager = fightManager;
            _userManager = userManager;
        }

        // GET: Fight
        public ActionResult FightMobById(int enemyId)
        {
            UsersModel model = new UsersModel();
            var userAspId= User.Identity.GetUserId();
            model = _userManager.GetModel(userAspId);

            var viewModel = new FightViewModel();
            viewModel.HtmlBody= _fightManager.Fight(model, enemyId);
            return View("FightMobById", viewModel);
        }
    }
}