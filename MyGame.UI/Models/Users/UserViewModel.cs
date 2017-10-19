using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;


namespace MyGame.UI.Models.Users
{
    public class UserViewModel

    {
       

        public int Id { get; set; }

        

        public string AspId { get; set; }

        [Display(Name = "Choose a name for your character:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Choose a class:")]
        
        public int ClassId { get; set; }

        public string Image { get; set; }
        public HttpPostedFileBase UploadedImage { get; set; }

        public List<SelectListItem> ClassList { get; set; }

        public string ErrorMessage { get; set; }

        public int Level { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public int Xp { get; set; }
        public int Xp_needed { get; set; }
        public string ClassName { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public List<FileDetailsModel> FileList { get; set; }

    }
}