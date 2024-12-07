using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MidTermGame
{
    public enum EnemyType
    {
        slime,
        goblin,
        ogre,
        skaletron
    }
    public class Enemy
    {
        
        private EnemyType[] enemies = {EnemyType.slime,EnemyType.goblin,EnemyType.skaletron,EnemyType.ogre};
        public EnemyType enemyType;
        public int PrizeMoney { get; set; }
        public Stats EnemyStat { get; set; }

        public float CurrentHealth { get; private set; }

        

        public Enemy(int playerLevel)
        {
            Random random = new Random();
            int randomIndex =  random.Next(0,enemies.Length);
            enemyType = enemies[randomIndex];

            EnemyStat = GetStatWithEnemyType(enemyType, playerLevel);
            PrizeMoney = GetPrizeMoney(enemyType,playerLevel);

            CurrentHealth = EnemyStat.maxHealth;
        }

        #region GetEnemyStat
        private Stats GetStatWithEnemyType(EnemyType type,int playerLevel)
        {
            switch (type)
            {
                case EnemyType.slime: return new Stats(
                    10 + playerLevel * 1,
                    5 + playerLevel * 1,
                    1.2f,
                    1.25f
                    );
                case EnemyType.goblin: return new Stats(
                    20 + playerLevel * 1,
                    5 + playerLevel * 1,
                    1.15f,
                    1.55f                    
                    );
                case EnemyType.skaletron: return new Stats(
                    20 + playerLevel * 2,
                    8 + playerLevel * 2,
                    1.25f,
                    1.5f
                    );
                case EnemyType.ogre: return new Stats(
                    25 + playerLevel * 3,
                    7 + playerLevel * 2,
                    1.30f,
                    2f
                    );
            }
            return EnemyStat;
        }

        private int GetPrizeMoney(EnemyType et,int level) {
            switch (et)
            {
                case EnemyType.slime:
                    return 15 + level * 1;
                case EnemyType.goblin:
                    return 15  + level * 2;
                case EnemyType.skaletron:  
                    return 30 + level * 2;
                case EnemyType.ogre:
                    return 50 + level * 3;
            }
            return 0;
        }
        public int GetPrizeExperiance(EnemyType et, int level)
        {
            switch (et)
            {
                case EnemyType.slime:
                    return 15 + level * 20;
                case EnemyType.goblin:
                    return 15 + level * 25;
                case EnemyType.skaletron:
                    return 30 + level * 30;
                case EnemyType.ogre:
                    return 50 + level * 35;
            }
            return 0;
        }
        public static ConsoleColor SelectColorForEnemyType(EnemyType et)
        {
            switch (et)
            {
                case EnemyType.slime: return ConsoleColor.Green;
                case EnemyType.goblin: return ConsoleColor.DarkYellow;
                case EnemyType.skaletron: return ConsoleColor.DarkGray;
                case EnemyType.ogre: return ConsoleColor.DarkCyan;
            }
            return ConsoleColor.White;
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
        #endregion

    }
}
