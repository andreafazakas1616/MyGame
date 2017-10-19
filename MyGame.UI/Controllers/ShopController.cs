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
    public class ShopController : Controller
    {
        private readonly ItemsManagerBLL _itemsManager = null;
        private readonly InventoryManagerBLL _inventoryManager = null;
        private readonly UsersManagerBLL _userManager = null;
        public ShopController(ItemsManagerBLL itemsManager, InventoryManagerBLL inventoryManager, UsersManagerBLL userManager)
        {
            _itemsManager = itemsManager;
            _inventoryManager = inventoryManager;
            _userManager = userManager;
        }
        // GET: Shop
        public ActionResult Shop()
        {
            List<ItemsModel> modelList = _itemsManager.GetModelList();
            List<ItemViewModel> viewModelList = ConvertToViewModelList(modelList);
            
            return View(viewModelList);
        }

        public ActionResult Buy(int itemId)
        {
            var aspUserId = User.Identity.GetUserId();
            UsersModel userModel= _userManager.GetModel(aspUserId);
            int userId = userModel.ID;
            _inventoryManager.AddItemModel(itemId, userId);
            return RedirectToAction("Shop");
        }

        private static List<ItemViewModel> ConvertToViewModelList(List<ItemsModel> modelList)
        {
            List<ItemViewModel> viewModelList = new List<ItemViewModel>();
            modelList.ForEach(s => viewModelList.Add(new ItemViewModel { Id = s.ID, Name = s.Item, Attack = s.Attack, Defense = s.Defense, HpRegen = s.HPregeneration }));
            return viewModelList;
        }
    }

    
}