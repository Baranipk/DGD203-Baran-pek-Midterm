using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MidTermGame
{
    internal class Game
    {
        private string hyphen = "---------------------";

        #region VARIABLES
        private bool _isRuning = false;
        private bool _isFighting = false;
        private bool _isDungeon = false;
        private bool _isBazaar = false;

        private int maxRoomCount = 10;
        private int roomIndex = 0;

        private int totalDungueonIncome = 0;

        private Player _player;
        private Enemy _curentEnemy;

        Random random = new Random();
        #endregion

        #region CONSTRUCTOR
        public Game() {
            _player = new Player();
        }
        #endregion

        public void StartGame()
        {
            Console.WriteLine("Game is Started...");
            GetPlayerName();
            StartGameLoop();
            GameLoop();
            Console.WriteLine("Game is Closed");
        }
        #region GET_PLAYER_NAME
        public void GetPlayerName()
        {
            Console.WriteLine("Please enter your name :   ");
            CheckPlayerName();
        }

        public void CheckPlayerName()
        {
            string name = Console.ReadLine();
            if (name.Trim() == "" || name == null)
            {
                Console.Write("Your Input is");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Wrong ! ");
                Console.ForegroundColor = ConsoleColor.White;
                GetPlayerName();
            }
            else {
                Console.Write("Welcome");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {name.Trim()} ");
                Console.ForegroundColor = ConsoleColor.White;
                _player.Initialize(name.Trim());

            }
        }
        #endregion

        #region GameLoop
        private void StartGameLoop() {
            _isRuning = true;
        }
        private void GameLoop()
        {
            while (_isRuning)
            {
                Menu();
            }
        }
        #endregion

        #region Menu
        private void Menu()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Where would you like to go?");

            Console.WriteLine("[1] Dungeon");
            Console.WriteLine("[2] Bazaar");
            Console.WriteLine("[3] Equipment");
            Console.WriteLine("[4] Stats");
            Console.WriteLine("[exit] Exit");

            CheckMenuInput();
        }

        private void CheckMenuInput()
        {
            string ınput = Console.ReadLine();
            if (ınput.ToLower().Trim() == "1")
            {
                Dungeon();
            }
            else if (ınput.ToLower().Trim() == "2")
            {
                Bazaar();
            }
            else if (ınput.ToLower().Trim() == "3")
            {
                Equipment.PrintEquipment(hyphen, _player);
            }
            else if (ınput.ToLower().Trim() == "4")
            {
                WriteStats();
            }
            else if (ınput.ToLower().Trim() == "exit")
            {
                
                _isRuning = false;
            }
            else {
                Console.Write("Your Input is");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Wrong ! ");
                Console.ForegroundColor = ConsoleColor.White;
            }


        }
        #endregion

        #region GAME_LOCİG

        #region BAZAAR

        #region BAZAAR_LOOP
        private void Bazaar()
        {
            _isBazaar = true;
            while (_isBazaar)
            {
                PrintUpgrades();
                string input = Console.ReadLine();
                switch (input.Trim().ToLower())
                {
                    case "1":
                        if(_player._PlayerEquipment.SwordUpgradeCost <= _player.Money)
                        {
                            _player.Money -= _player._PlayerEquipment.SwordUpgradeCost;
                            _player._PlayerEquipment.SwordUpgradeCost += 250;
                            _player._PlayerStats.BuySwordForStat();
                            _player._PlayerEquipment.SwordLevel++;

                            Console.WriteLine($"Your Sword Upgrade to {_player._PlayerEquipment.SwordLevel} Level");
                            Console.WriteLine("You Got 2 Atack Point");

                            
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Not enough Gold");
                            Console.ForegroundColor = ConsoleColor.White;                            
                            Console.Write("You Need :");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{_player._PlayerEquipment.SwordUpgradeCost - _player.Money} Gold");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();

                        }
                        break;
                    case "2":
                        if (_player._PlayerEquipment.HelmetUpgradeCost <= _player.Money)
                        {
                            _player.Money -= _player._PlayerEquipment.HelmetUpgradeCost;
                            _player._PlayerEquipment.HelmetUpgradeCost += 250;
                            _player._PlayerStats.BuyHelmetForStat();
                            _player._PlayerEquipment.HelmetLevel++;

                            Console.WriteLine($"Your Helmet to {_player._PlayerEquipment.HelmetLevel} Level");
                            Console.WriteLine("You Get 0.05 Crit Rate");
                            Console.WriteLine("You Get 0.1 Crit Damage");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough Gold");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("You Need :");                            
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{_player._PlayerEquipment.HelmetUpgradeCost - _player.Money} Gold");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            
                        }
                        break;
                    case "3":
                        if (_player._PlayerEquipment.ArmourUpgradeCost <= _player.Money)
                        {
                            _player.Money -= _player._PlayerEquipment.ArmourUpgradeCost;
                            _player._PlayerEquipment.ArmourUpgradeCost += 250;
                            _player._PlayerStats.BuyArmourForStat();
                            _player._PlayerEquipment.ArmourLevel++;

                            Console.WriteLine($"Your Armour Upgrade to {_player._PlayerEquipment.ArmourLevel}  Level");
                            Console.WriteLine("You Get 5 Health Point");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough Gold");
                            Console.ForegroundColor = ConsoleColor.White;
                            
                            Console.Write("You Need :");                          
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{_player._PlayerEquipment.ArmourUpgradeCost - _player.Money} Gold");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            
                            
                        }
                        break;
                    case "exit":
                        _isBazaar = false;
                        break;
                    default:
                        Console.Write("Input is");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Wrong ! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            #endregion

        }

        private void PrintUpgrades()
        {
            Console.WriteLine(hyphen);
            Console.Write("Player Have : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_player.Money} Gold ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose Your Equipment And Upgrade");
            Console.WriteLine(hyphen);
            Console.WriteLine($"[1] Sword {_player._PlayerEquipment.SwordUpgradeCost} gold For Upgrade to {_player._PlayerEquipment.SwordLevel+1} Level");
            Console.WriteLine($"[2] Helmet {_player._PlayerEquipment.HelmetUpgradeCost} gold For Upgrade to {_player._PlayerEquipment.HelmetLevel + 1} Level");
            Console.WriteLine($"[3] Armour {_player._PlayerEquipment.ArmourUpgradeCost} gold For Upgrade to {_player._PlayerEquipment.ArmourLevel + 1}  Level");
            Console.WriteLine("[exit] Exit");
        }
        #endregion
        #region Stats
        private void WriteStats() {

            Console.WriteLine(hyphen);
            Console.WriteLine($"Player Level :{_player.Level}");
            _player.PrintXptoLevel();
            Console.WriteLine(hyphen);
            WriteStatInfo("Maximum Health :", _player._PlayerStats.maxHealth.ToString(), ConsoleColor.Green);
            WriteStatInfo("Atack Damage :", _player._PlayerStats.atackDamage.ToString(), ConsoleColor.Red);
            WriteStatInfo("Critic Rate :", _player._PlayerStats.critRate.ToString(), ConsoleColor.Yellow);
            WriteStatInfo("Critic Damage :", _player._PlayerStats.critDamage.ToString(), ConsoleColor.Magenta);
        }

        private void WriteStatInfo(string text, string statText, ConsoleColor color) {

            Console.Write(text);
            Console.ForegroundColor = color;
            Console.Write($" {statText}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        #endregion
        #region Dungeon

        private void Dungeon()
        {
            _player.CurrentHealth = _player._PlayerStats.maxHealth;
            _isDungeon = true;
            totalDungueonIncome = 0;
            while (_isDungeon)
            {
                EnterRoom();
            }

        }

        #region Entering_Room
        private void EnterRoom()
        {
            if (roomIndex < maxRoomCount)
            {
                roomIndex++;
                Console.WriteLine($"You Entered Room [{roomIndex}/ 10]");
                if(totalDungueonIncome > 0) PrintTotalIncomeInDungeon();               
                Console.Write("Health :");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write($"[{_player.CurrentHealth} / {_player._PlayerStats.maxHealth}]");
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("");

                _curentEnemy = new Enemy(_player.Level);
                PrintEnemy();
                CheckFight();

            }
            else
            {
                ExitDungeon();
            }

        }
        #endregion

        #region FİGHT

        #region Print_Enemy
        private void PrintEnemy() {
            Console.WriteLine(hyphen);
            Console.Write("Enemy Spotted ");
            Console.ForegroundColor = Enemy.SelectColorForEnemyType(_curentEnemy.enemyType);
            Console.Write(_curentEnemy.enemyType.ToString().ToUpper());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        #endregion

        #region Check_Fight
        private void CheckFight()
        {
            Console.Write("Do You Want to Fight ? ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ YES");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" OR ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NO ]");
            Console.ForegroundColor = ConsoleColor.White;



            while (true)
            {
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "yes")
                {
                    _isFighting = true;
                    FightLoop();
                    break;
                }
                else if (input.Trim().ToLower() == "no")
                {
                    _player.Money += totalDungueonIncome;
                    totalDungueonIncome = 0;

                    ExitDungeon();
                    break;
                }
                else
                {
                    Console.Write("Please just write : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[YES");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" OR ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("NO]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
        #endregion

        #region FigtLoop
        private void FightLoop()
        {
            while (_isFighting)
            {
                
                if(_curentEnemy.CurrentHealth > 0)
                {
                    Thread.Sleep(1000);
                    PrintEnemyRound();                   
                }
                else
                {
                    _isFighting = false;
                    //total Income
                    PrintPrizeMonster();
                    _player.GetXp(_curentEnemy.GetPrizeExperiance(_curentEnemy.enemyType,_player.Level));
                    totalDungueonIncome += _curentEnemy.PrizeMoney;
                    break;
                }

                if (_player.CurrentHealth > 0)
                {
                    Thread.Sleep(1000);
                    PrintPlayerRound();
                }
                else
                {
                    _isFighting = false;
                    LostMoney();
                    totalDungueonIncome = 0;
                    ExitDungeon();
                    break;
                }
                
            }           
        }

        #endregion

        #region PrintEnemyRound
        private void PrintEnemyRound()
        {
            Console.WriteLine(hyphen);
            Console.Write($"Enemy ");
            Console.ForegroundColor = Enemy.SelectColorForEnemyType(_curentEnemy.enemyType);
            Console.Write($" {_curentEnemy.enemyType.ToString().ToUpper()} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Health ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[ {_curentEnemy.CurrentHealth} / {_curentEnemy.EnemyStat.maxHealth} ] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            AttackPlayer();

        }
        #endregion

        #region PrintPlayerRound
        private void PrintPlayerRound()
        {
            Console.WriteLine(hyphen);
            Console.Write($"Player ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{_player.Name.ToUpper()}");
            Console.ForegroundColor = ConsoleColor.White;           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  Health ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[ {_player.CurrentHealth} / {_player._PlayerStats.maxHealth} ] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            AttackEnemy();
            
        }
        #endregion

        #region Attack_Player
        private void AttackPlayer()
        {
            if(CalculateCrit(_curentEnemy.EnemyStat.critRate) == true)
            {
                float damage = _curentEnemy.EnemyStat.atackDamage * _curentEnemy.EnemyStat.critDamage;
                Console.Write($"Enemy ");
                Console.ForegroundColor = Enemy.SelectColorForEnemyType(_curentEnemy.enemyType);
                Console.Write($" {_curentEnemy.enemyType.ToString().ToUpper()} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hit.. ");
                PrintCriticAttack(damage);
                if (!_player.GetHit(damage))
                {
                    Console.WriteLine("Player Death");
                    Console.WriteLine(hyphen);                                       
                }

            }
            else
            {
                float damage = _curentEnemy.EnemyStat.atackDamage;
                Console.Write($"Enemy ");
                Console.ForegroundColor = Enemy.SelectColorForEnemyType(_curentEnemy.enemyType);
                Console.Write($" {_curentEnemy.enemyType.ToString().ToUpper()} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hit.. ");
                PrintNormalAttack(damage);

                if (!_player.GetHit(damage))
                {
                    Console.WriteLine("Player Death");
                    Console.WriteLine(hyphen);                    
                }
            }
        }
        #endregion

        #region Attack_Enemy
        private void AttackEnemy()
        {
            if (CalculateCrit(_player._PlayerStats.critRate) == true)
            {
                float damage = _player._PlayerStats.atackDamage * _player._PlayerStats.critDamage;
                Console.Write($"Player ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{_player.Name.ToUpper()} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hit.. ");
                PrintCriticAttack(damage);

                if (!_curentEnemy.GetHit(damage))
                {
                    Console.WriteLine("Enemy Death");
                    Console.WriteLine(hyphen);                    
                }
            }
            else
            {
                float damage = _player._PlayerStats.atackDamage;
                Console.Write($"Player ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {_player.Name.ToUpper()} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hit.. ");
                PrintNormalAttack(damage);
                if (!_curentEnemy.GetHit(damage))
                {
                    Console.WriteLine("Enemy Death");                 
                }
            }
        }
        #endregion

        #region Calculate_Crit
        private bool CalculateCrit(float critrate)
        {
            int rate = (int)((critrate - 1) * 100);            
            int nummber = random.Next( 0 , 100);            
            if (nummber > rate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Print_Attacks
        private void PrintNormalAttack(float attack) {          
            Console.Write($"   normal Attack {attack}");
            Console.WriteLine();
            
        }
        private void PrintCriticAttack(float attack) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"   Critical Attack {attack}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        #endregion

        #region print_Monster_prize
        private void PrintPrizeMonster()
        {
            Console.Write("You Got ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{_curentEnemy.PrizeMoney} Gold");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" in ");
            Console.ForegroundColor = Enemy.SelectColorForEnemyType(_curentEnemy.enemyType);
            Console.Write($"{_curentEnemy.enemyType.ToString().ToUpper()}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(hyphen);           
        }

        #endregion

        #region Print_Lost_Money
        private void LostMoney()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write("You Lost ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{totalDungueonIncome} Gold");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();            
        }
        #endregion

        private void PrintTotalIncomeInDungeon()
        {
            Console.Write("You Have total");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {totalDungueonIncome} Gold ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("If you die you lose all Gold");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(hyphen);
        }



        #endregion

        private void ExitDungeon()
        {
            roomIndex = 0;
            _isDungeon = false;
            Console.WriteLine("Exiting The Dungeon");
        }

        #endregion

        #endregion
    }
}
