
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FirstFantazy_StoryText;

using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;
using FirstFantazy.Story;
using FirstFantazy.Core;


namespace FirstFantazy_Battle
{
    public class Battle
    {
        bool mainHeroLive = true;

        int selectedEnemy, j = 0, i = 0, durabilityDown = 0;

        private List<Hero> heroes;
        private List<Hero> enemies;

        Random randomAttack = new Random();

        public Battle(List<Hero> heroes, List<Hero> enemies)
        {
            this.heroes = heroes;
            this.enemies = enemies;
        }

        private void Attack(Hero atacker, Hero enemy)
        {
            Weapon weapon = atacker.Inventory[0] as Weapon;

            if (weapon != null && atacker.Durability > 0)
            {
                if (enemy.Durability < weapon.Hardness)
                {
                    enemy.Durability -= weapon.Damage;

                    BattleText.BattleStats(weapon, enemy);

                    if (enemy.Durability == 0)
                    {
                        enemy.Life -= weapon.Damage;
                    }

                    if (enemy.Life <= 0)
                    {
                        BattleText.OpponentDefeated();
                        enemy.IsLife = false;
                    }

                    atacker.HeroDurabilityDownUp(durabilityDown, 0);

                    BattleText.BattleDurabilityDown(atacker);
                
                }
                else
                {
                    BattleText.TheWeaponDoesNotHurt();
                
                    weapon.Hardness--;

                    BattleText.StateOfArms(weapon);

                    if (weapon.Hardness <= 0)
                    {
                        heroes[j].Inventory[0] = null;
                        BattleText.WeaponDestroyed(weapon);
                    }
                }
            }
            else
            {
                if (atacker.Durability == 0)
                {
                    BattleText.DurabilityDownZero(atacker);
                }
                if (weapon == null)
                {
                    BattleText.NoWeapon();
                }   
            }
            if (!enemy.IsLife)
            {
                enemies.Remove(enemy);
            }
        }

        public List<Hero> Initialize()
        {
            BattleText.BattleStart();
            Console.Clear();

            do
            {
                durabilityDown++;

                j = randomAttack.Next(0, heroes.Count);

                Weapon weapon = heroes[j].Inventory[0] as Weapon;

                StoryText.SetColor(ConsoleColor.Green);

                if (weapon.Hardness <= 0)
                {
                    Console.WriteLine();
                    StoryText.HeroColorText(heroes[j]);
                    BattleText.InformationWeaponDestroyed();
                }
                else
                {
                    BattleText.PresentationOfAttacker(heroes[j]);

                    if (j == 0)
                    {
                        BattleText.PresentationEnemies(enemies);
                    }
                    else
                    {
                        BattleText.CompanionAtackEnemyPresentation(enemies);
                    }

                    if (j == 1)
                    {
                        selectedEnemy = randomAttack.Next(0, enemies.Count);

                        BattleText.HeroRandomAttack(heroes, enemies, j, selectedEnemy);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 25);
                        BattleText.SelectEnemyNumber();
                        selectedEnemy = GameCore.GetInputValueHandlingExceptions(1, 0, 2);
                    }

                    Attack(heroes[j], enemies[selectedEnemy]);

                    StoryText.ResetColor();

                    if (enemies.Count > 0)
                    {
                        i = randomAttack.Next(0, enemies.Count);

                        var heroesNumber = randomAttack.Next(0, heroes.Count);

                        BattleText.RandomEnemyAttack(heroes, enemies, j, i);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Weapon weaponEn = enemies[i].Inventory[0] as Weapon;

                        BattleText.PresentationOfAttacker(enemies[i]);

                        Attack(enemies[i], heroes[heroesNumber]);
                 
                        //StoryText.SelectWayDisplayDelay(4);
                        Console.Clear();

                        if (!heroes[heroesNumber].IsLife)
                        {
                            if (heroes[heroesNumber] == heroes[0])
                            {
                                mainHeroLive = false;
                            }
                        }
                        Console.ResetColor();
                    }
                }

            } while (enemies.Count > 0 && mainHeroLive);

            return heroes;
        }
    }

}

