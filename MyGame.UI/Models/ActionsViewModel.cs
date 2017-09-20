using System.Collections.Generic;

namespace MyGame.UI.Models
{
    public class ActionsViewModel
    {
        public ActionsViewModel()
        {
            ActionList = new List<ActionRowViewModel>();
        }
        public List<ActionRowViewModel> ActionList {get;set;}
    }
}