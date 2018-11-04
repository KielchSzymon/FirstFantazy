﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FirstFantazy_StoryText;

using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;
using FirstFantazy.Story;


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

            StoryText.HeroCondition(atacker);

            if (weapon != null && atacker.Durability > 0)
            {
                if (enemy.Durability < weapon.Hardness)
                {
                    enemy.Durability -= weapon.Damage;

                    StoryText.BattleStats(weapon, enemy);

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

                    StoryText.BattleDurabilityDown(atacker);
                
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
                    StoryText.DurabilityDownZero(atacker);
                }
                if (weapon == null)
                {
                    StoryText.NoWeapon();
                }   
            }
            if (!enemy.IsLife)
            {
                enemies.Remove(enemy);
            }
        }

        public List<Hero> Initialize()
        {
            StoryText.BattleStart();

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
                    StoryText.PresentationOfAttacker(heroes[j]);

                    StoryText.PresentationEnemies(enemies);



                    if (j == 1)
                    {
                        selectedEnemy = randomAttack.Next(0, enemies.Count);

                        BattleText.HeroRandomAttack(heroes, enemies, j, selectedEnemy);

                    }
                    else
                    {
                        selectedEnemy = Int16.Parse(StoryText.DownloadingData()) - 1;
                    }

                    Attack(heroes[j], enemies[selectedEnemy]);

                    StoryText.ResetColor();

                    if (enemies.Count > 0)
                    {
                        i = randomAttack.Next(0, enemies.Count);

                        var heroesNumber = randomAttack.Next(0, heroes.Count);

                        BattleText.RandomEnemyAttack(heroes, enemies, j, i);

                        Console.WriteLine();
                        Console.WriteLine("Atakuje losowo przeciwnik " + enemies[i].Name);

                        Console.WriteLine("Atkuje losowo bohatera " + heroes[j].Name);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Red;

                        Weapon weaponEn = enemies[i].Inventory[0] as Weapon;

                        StoryText.PresentationOfAttacker(enemies[i]);

                        Attack(enemies[i], heroes[heroesNumber]);

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

