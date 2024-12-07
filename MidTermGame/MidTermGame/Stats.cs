using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermGame
{
    public struct Stats
    {
        public float maxHealth;
        public int atackDamage;
        public float critRate;
        public float critDamage;

        public Stats(int HP, int AD, float CR, float CD)
        {
            this.maxHealth = HP;
            this.atackDamage = AD;
            this.critRate = CR;
            this.critDamage = CD;
        }

        public void UpgradeStatsForLevelUp()
        {
            maxHealth += 5;
            atackDamage += 1;
            critRate += 0.05f;
            critDamage += 0.1f;
        }

        public void BuyHelmetForStat()
        {
            critRate += 0.05f;
            critDamage += 0.1f;
        }

        public void BuyArmourForStat()
        {
            maxHealth += 5;
        }

        public void BuySwordForStat()
        {
            atackDamage += 2;
        }

    }
}
