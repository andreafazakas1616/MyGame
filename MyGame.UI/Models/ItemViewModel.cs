using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.UI.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HpRegen { get; set; }
    }
}