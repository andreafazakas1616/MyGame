using System.Web;

namespace MyGame.UI.Models.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username_Id { get; set; }
        public string Username { get; set; }
        public int Class { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}