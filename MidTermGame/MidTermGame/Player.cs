using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidTermGame
{
    public class Player
    {
        public string Name { get; private set; }
        public int Money { get; set; }
        public int Level { get; set; } = 1;

        public Stats _PlayerStats;

        public Equipment _PlayerEquipment;
        public float CurrentHealth {  get; set; }

        public float CurrentExperiance { get; set; }
        public float ExperianceRequiredToLevelUp { get; private set; }

        public Player(string name = "_Blank")
        {
            Name = name;
        }

        public void Initialize(string name)
        {
            Name = name;
            _PlayerStats = new Stats(50,10,1.25f,1.5f);
            CurrentHealth = _PlayerStats.maxHealth;
            CurrentExperiance = 0;
            ExperianceRequiredToLevelUp = 150;
            _PlayerEquipment = new Equipment(0,0,0);
        }

        public bool GetHit(float damage)
        {
            if (damage < CurrentHealth)
            {
                CurrentHealth -= damage;
                return true;
            }
            else
            {

                CurrentHealth = 0;
                return false;
            }
        }

        public void GetXp(float xp)
        {
            CurrentExperiance += xp;
            PrintXp(xp);
            if(CurrentExperiance >= ExperianceRequiredToLevelUp)
            {
                CurrentExperiance -= ExperianceRequiredToLevelUp;
                Level++;
                ExperianceRequiredToLevelUp += Level * 50;
                _PlayerStats.UpgradeStatsForLevelUp();
                PrintLevelUp();
                PrintXptoLevel();
            }
            else
            {
                PrintXptoLevel();
            }
        }

        public void PrintLevelUp()
        {
            Console.WriteLine("----------------------");
            Console.Write($"level up to lv.{Level}");
            Console.WriteLine();
        }

        public void PrintXp(float xp)
        {            
            
            Console.Write($"You Get   ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{xp.ToString("F0")} XP");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine();
        }

        public void PrintXptoLevel()
        {
            Console.Write("You Need ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{ExperianceRequiredToLevelUp - CurrentExperiance} xp");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write(" To Level Up ");
            Console.WriteLine();
        }

        

    }
}
