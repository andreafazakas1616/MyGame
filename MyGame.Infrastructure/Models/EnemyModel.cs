using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Infrastructure.Models
{
    public class EnemyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HP { get; set; }
    }
}
