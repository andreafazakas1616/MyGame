using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Infrastructure.Models
{
    public class ItemsModel
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HPregeneration { get; set; }
    }
}
