using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonDrama
{
    class Attack
    {
        int playerHealth = 1;
        int enemyHealth = 1;
        bool playerAttackSuccess;
        Random chance = new Random();
        int attackchance;
        public void attackdraw()
        {
            attackchance = chance.Next(0, 2);
            if (attackchance == 1)
            {
                playerAttackSuccess = true;
            }
            else
            {
                playerAttackSuccess = false;
            }
            
        }
        public bool attackoption()
        {
            Console.WriteLine("Do you want to fight?\n" +
                "Type yes or no");
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == "yes")
            {
                //attackdraw();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool attackSuccess()
        {
            if (playerAttackSuccess == true)
            {
                enemyHealth = 0;
                return true;
            }
            else
            {
                playerHealth = 0;
                return false;
            }
        }
    
    }
}
