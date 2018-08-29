using FirstFantazy.Player;
using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;
using System.Text;


namespace FirstFantazy
{
    public class Battle
    {

        #region ClassBoxes

        bool mainHeroLive = true;

        #endregion ClassBoxes

        public Battle(List<Hero> heroes, List<Hero> enemies)
        {
            int select, j = 0, i = 0;

            Random randomAttack = new Random();
            MyMethods myMethods = new MyMethods();

            Console.WriteLine("Bitwa!!!");
            Console.WriteLine();

            Console.WriteLine("Jesteś zmuszony stawić czoło przeciwnikom.");
            Console.WriteLine();

            do
            {
                #region HeroesAttack

                #region PresentationOfHero

                Console.ForegroundColor = ConsoleColor.Green;

                j = randomAttack.Next(0, 2);

                Weapon weapon = heroes[j].Inventory[0] as Weapon; // nie rozumiem

                Console.WriteLine();
                Console.WriteLine("Atak bohatera!");
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Console.WriteLine($"Kolej gracza [{heroes[j].Name}]");
                Console.WriteLine($"Używa broni [{ weapon.WeponName}]");
                Console.WriteLine($"O wytrzymałości [{ weapon.Hardness}]");
                Console.WriteLine($"Zadającej obrażenia na poziomie [{weapon.Damage}].");
                Console.WriteLine("==================================================================");
                Console.WriteLine();

                #endregion PresentationOfHero

                i = 0;

                #region PresentationOfEnemies

                foreach (Hero hero in enemies)
                {
                    Console.WriteLine(enemies[i].Name + " atakuj - " + i);

                    Console.WriteLine();
                    Console.WriteLine($"Stan wroga: {enemies[i].Name} ");
                    Console.WriteLine($"Życie: {enemies[i].Life}");
                    Console.WriteLine($"Wytrzymałość: {enemies[i].Durability}");
                    Console.WriteLine("");
                    Console.WriteLine();

                    i++;
                    Console.WriteLine();
                }

                #endregion PresentationOfEnemies

                //i = 0;

                if (j == 1)
                {
                    select = randomAttack.Next(0, 2);
                }
                else
                {
                    select = Convert.ToInt16(myMethods.DownloadingData());
                }

                Hero enemy = enemies[select];

                #region WeaponAttack

                if (weapon.WeponName == "Stick")// Problem z warunkiem, powinien być uniwersalny, jeżeli nie ma broni to...
                {
                    if (enemy.Durability < weapon.Hardness)
                    {
                        enemy.Durability -= weapon.Damage;

                        Console.WriteLine();
                        Console.WriteLine($"Twoja broń zadaje [{weapon.Damage}] obrażeń.");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine($"Stan wroga: {enemies[select].Name} ");
                        Console.WriteLine($"Życie: {enemies[select].Life}");
                        Console.WriteLine($"Wytrzymałość: {enemies[select].Durability}");
                        Console.WriteLine("");
                        Console.WriteLine();

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
                        Console.WriteLine();
                        Console.WriteLine("Broń nie czyni krzywdy przeciwnikowi, za to traci 1 punkt wytrzymałości.");
                        Console.WriteLine();

                        weapon.Hardness--;

                        Console.WriteLine($"Po stracie punktu broń ma wytrzymałość: {weapon.Hardness}");

                        if (weapon.Hardness <= 0)
                        {
                            heroes[j].Inventory[0] = null;
                            Console.WriteLine("Twoja broń {0}, uległa zniszczeniu!", weapon.WeponName);
                        }

                        //jak wytrzymalosc broni spada ponizej zera usun bron
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Nie posiadasz żadnej broni, nie możesz atakowac! Atakuje ten kto ma broń");
                    Console.WriteLine();
                }

                #endregion WeaponAttack

                if (!enemy.IsLife)
                {
                    enemies.Remove(enemy);
                }

                Console.ResetColor();

                #endregion EndOfHeroesAttack 

                #region EnemiesAttack         

                if (enemies.Count > 0)
                {
                    i = randomAttack.Next(0, 2);

                    Console.WriteLine("Atakuje losowo przeciwnik " + enemies[i].Name);

                    j = randomAttack.Next(0, 2);

                    Console.WriteLine("Atkuje losowo bohatera " + heroes[j].Name);

                    #region PresentationOfEnemies

                    Console.ForegroundColor = ConsoleColor.Red;

                    Weapon weaponEn = enemies[i].Inventory[0] as Weapon;

                    Console.WriteLine();
                    Console.WriteLine("Atak przeciwnika!");

                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine($"Kolej przeciwnika [{enemies[i].Name}]");
                    Console.WriteLine($"Używa broni [{ weaponEn.WeponName}]");
                    Console.WriteLine($"O wytrzymałości [{ weaponEn.Hardness}]");
                    Console.WriteLine($"Zadającej obrażenia na poziomie [{weaponEn.Damage}].");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine();

                    #endregion PresentationOfEnemies

                    #region WeaponAttack

                    if (weaponEn.WeponName == "Arm")// Problem z warunkiem, powiniec być uniwersalny, jeżeli nie ma broni to...
                    {
                        if (heroes[j].Durability < weaponEn.Hardness)
                        {
                            heroes[j].Durability -= weaponEn.Damage;

                            Console.WriteLine();
                            Console.WriteLine($"Broń przeciwnika zadaje [{weaponEn.Damage}] obrażeń.");
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.WriteLine($"Stan bohatera: {heroes[j].Name} ");
                            Console.WriteLine($"Życie: {heroes[j].Life}");
                            Console.WriteLine($"Wytrzymałość: {heroes[j].Durability}");
                            Console.WriteLine("");
                            Console.WriteLine();

                            Console.WriteLine();

                            if (heroes[j].Durability == 0)
                            {
                                heroes[j].Life -= weaponEn.Damage;
                            }

                            if (heroes[j].Life <= 0)
                            {
                                Console.WriteLine($"Bohater: {heroes[j].Name} został pokonany");
                                heroes[j].IsLife = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Broń przeciwnika nie czyni krzywdy bohaterowi, za to traci 1 punkt wytrzymałości.");
                            Console.WriteLine();

                            weaponEn.Hardness--;

                            Console.WriteLine($"Po stracie punktu broń ma wytrzymałość: {weaponEn.Hardness}");
                            Console.WriteLine();

                            if (weaponEn.Hardness <= 0)
                            {
                                enemies[i].Inventory[0] = null;
                                Console.WriteLine("Broń {0}, uległa zniszczeniu!", weaponEn.WeponName);
                            }

                            //jak wytrzymalosc broni spada ponizej zera usun bron
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Przeciwnik nie posiada żadnej broni, nie może atakowac! Atakuje ten kto ma broń");
                        Console.WriteLine();
                    }

                    #endregion WeaponAttack

                    if (!heroes[j].IsLife)
                    {
                        //heroes.Remove(heroes[j]);

                        if (heroes[j] == heroes[0])
                        {
                            mainHeroLive = false;
                        }
                    }

                    //i = 0;
                    Console.ResetColor();
                }
                
                #endregion EnemiesAttack

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

        }
    }
    
}
