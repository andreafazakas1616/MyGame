namespace MyGame.Infrastructure.Models
{
    public class UsersModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Class_ID { get; set; }
        public int XP { get; set; }
        public int XP_needed { get; set; }
        public string Asp_Id { get; set; }
        public string Image { get; set; }
        public string ErrorMessage { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
    }
}
