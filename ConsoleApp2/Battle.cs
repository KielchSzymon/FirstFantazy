using FirstFantazy.Player;
using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;
using System.Text;
using FirstFantazy.Story;
using System.Threading;

namespace FirstFantazy
{
    public class Battle
    {
        bool mainHeroLive = true;

        int selectedEnemy, j = 0, i = 0;

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

            if (weapon != null)
            {
                if (enemy.Durability < weapon.Hardness)
                {
                    enemy.Durability -= weapon.Damage;

                    StoryText.BattleStats(weapon, enemy);

                    Console.WriteLine();

                    if (enemy.Durability == 0)
                    {
                        enemy.Life -= weapon.Damage;
                    }

                    if (enemy.Life <= 0)
                    {
                        Console.WriteLine("Pokonujesz wroga:");
                        enemy.IsLife = false;
                    }
                }
                else
                {
                    Console.WriteLine("Broń nie czyni krzywdy przeciwnikowi, za to traci 1 punkt wytrzymałości.");

                    weapon.Hardness--;

                    Console.WriteLine($"Po stracie punktu broń ma wytrzymałość: {weapon.Hardness}");

                    if (weapon.Hardness <= 0)
                    {
                        heroes[j].Inventory[0] = null;
                        Console.WriteLine("Twoja broń {0}, uległa zniszczeniu!", weapon.WeponName);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Nie posiadasz żadnej broni, nie możesz atakowac! Atakuje ten kto ma broń");
                Console.WriteLine();
            }


            if (!enemy.IsLife)
            {
                enemies.Remove(enemy);
            }


        }

        public List<Hero> Initialize()
        {

            MyMethods myMethods = new MyMethods();

            StoryText.BattleStart();

            do
            {

                StoryText.SetColor(ConsoleColor.Green);

                StoryText.PresentationOfAttacker(heroes[j]);

                StoryText.PresentationEnemies(enemies);

                if (j == 1)
                {
                    selectedEnemy = randomAttack.Next(0, 2);

                    Console.WriteLine();
                    Console.WriteLine($"{heroes[j].Name}, atkuje losowo wybranego przeciwnika {enemies[selectedEnemy].Name}");
                    Console.WriteLine();
                }
                else
                {
                    selectedEnemy = Int16.Parse(Console.ReadLine())-1;
                }

                Attack(heroes[j], enemies[selectedEnemy]);

                StoryText.ResetColor();

                if (enemies.Count > 0)
                {
                    i = randomAttack.Next(0, enemies.Count);

                    var heroesNumber = randomAttack.Next(0, heroes.Count);

                    Console.WriteLine("Atakuje losowo przeciwnik " + enemies[i].Name);

                    Console.WriteLine("Atkuje losowo bohatera " + heroes[j].Name);

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

         

                //dodaj ataki przeciwnikow
                //a tutaj jak maja atakowac po pierwszym graczu

                //if (j < 1)
                //{
                //    //a tutaj jak maja atakowac na zmiane
                //    j++;
                //}
                //else
                //{
                //    //tu moze byc przykladowo etap ataku przecinikow jak maja atakowac po graczach
                //    j = 0;
                //}

            } while (enemies.Count > 0 && mainHeroLive);


            return heroes;
        }
    }

}

