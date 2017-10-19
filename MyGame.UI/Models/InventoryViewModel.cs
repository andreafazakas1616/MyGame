using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyGame.UI.Models
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        [Display(Name="Hp regeneration ")]
        public int HpRegen { get; set; }
    }
}