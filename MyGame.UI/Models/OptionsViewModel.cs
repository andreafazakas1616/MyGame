using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.UI.Models
{
    public class OptionsViewModel
    {
        public OptionsViewModel()
        {
            OptionsList = new List<OptionsRowViewModel>();
        }

        public List<OptionsRowViewModel> OptionsList { get; set; }
    }
}