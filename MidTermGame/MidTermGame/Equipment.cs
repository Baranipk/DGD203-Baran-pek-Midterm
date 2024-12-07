using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermGame
{
    public struct Equipment
    {
        public int HelmetLevel;
        public int ArmourLevel;
        public int SwordLevel;

        public int HelmetUpgradeCost;
        public int ArmourUpgradeCost;
        public int SwordUpgradeCost;

        public Equipment(int Hlevel ,int Alevel ,int Slevel)
        {
            this.HelmetLevel = Hlevel;
            this.ArmourLevel = Alevel;
            this.SwordLevel = Slevel;

            HelmetUpgradeCost = 250;
            ArmourUpgradeCost = 250;
            SwordUpgradeCost = 250;
        }
        static public void PrintEquipment(string hyphen,Player player)
        {
            Console.WriteLine(hyphen);
            Console.WriteLine("Player Have : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Money} Gold ");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine(hyphen);
            Console.WriteLine($"Helmet Level : {player._PlayerEquipment.HelmetLevel}");
            Console.WriteLine($"Armour Level : {player._PlayerEquipment.ArmourLevel}");
            Console.WriteLine($"Sword Level : {player._PlayerEquipment.SwordLevel}");
        }
    }
}
