using MyGame.DAL.Repository;
using MyGame.Infrastructure.Models;


namespace MyGame.BLL.Managers
{
    public class FightManagerBLL
    {
        private readonly UsersModel _userModel = null;
        private readonly EnemyModel _enemyModel = null;
        private readonly UsersRepository _userRepository = null;
        private readonly EnemyManagerBLL _enemyManagerBLL = null;

        public FightManagerBLL(UsersModel userModel, EnemyModel enemyModel, UsersRepository userRepo, EnemyManagerBLL enemyManagerBLL)
        {
            _userModel = userModel;
            _enemyModel = enemyModel;
            _userRepository = userRepo;
            _enemyManagerBLL = enemyManagerBLL;
        }

        public string Fight(UsersModel userModel, int enemyId)
        {
            var enemyModel = _enemyManagerBLL.GetEnemyById(enemyId);
            var HtmlBody = "";
            

            while (userModel.HP > 0 && enemyModel.HP > 0)
            {
                if (userModel.Armor < enemyModel.Attack)
                {
                    userModel.HP--;
                    HtmlBody += "<p>The enemy hits you for " + (enemyModel.Attack - userModel.Armor).ToString() + " damage</p>";
                }
                if (userModel.Attack > enemyModel.Defense)
                {
                    enemyModel.HP--;
                    HtmlBody += "<p>You hit the enemy for " + (userModel.Attack - enemyModel.Defense).ToString() + " damage</p>";
                }
            }

            if (userModel.HP > 0 && enemyModel.HP <= 0)
            {
               
                userModel.XP = userModel.XP + enemyModel.XP_given;
                _userRepository.IncrementExperience(userModel.ID, enemyModel.XP_given);
                HtmlBody += $"<p>You won! As a result, you gain {enemyModel.XP_given} experience</p>";

                if (userModel.XP_needed <= userModel.XP)
                {
                    _userRepository.IncrementLevelAndStats(userModel.ID);
                    
                    HtmlBody += $"<p>Congratulations! You have reached level {userModel.Level+1}</p>";
                }
                
            }
            else
            {
                _userRepository.PlayerLostABattle(userModel.ID);
                
                HtmlBody += $"<p>Ripperoni in pepperoni</p>";
            }

            return HtmlBody;
        }
    }
}
