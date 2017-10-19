using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyGame.UI.Models.Users
{
    public class UserItemViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Item: ")]
        public string ItemName { get; set; }

        [Display(Name ="Armor: +")]
        public int ItemArmor { get; set; }

        [Display(Name ="Attack: +")]
        public int ItemAttack { get; set; }

        [Display(Name ="HP regeneration: +")]
        public int ItemHp { get; set; }
    }
}