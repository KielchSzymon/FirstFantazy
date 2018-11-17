
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;
using FirstFantazy_Graphic_Game_Objects;




namespace FirstFantazy_StoryText
{
    public class StoryText
    {
        private const int i = 4;

        public static void SelectWayDisplayDelay(int i)
        {
            if (i==0)
            {
                Console.WriteLine();
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }
            if (i == 1)
            {
                Console.SetCursorPosition(Console.CursorLeft+29,Console.CursorTop);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            if (i == 2)
            {

                Console.SetCursorPosition(Console.CursorLeft + 29, Console.CursorTop);

                Console.CursorVisible = false;
            
                Thread.Sleep(3000);

                Console.CursorVisible = true;

            }
            if (i == 3)
            {
                Thread.Sleep(3000);
            }
            if (i == 4)
            {
                Console.SetCursorPosition(0,25);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            if (i == 5)
            {
                Console.SetCursorPosition(0, 25);
                Console.Write("Press any key to continue...");
            }
            else
            {
                //Thread.Sleep(3000);
            }
        }

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        public static void BattleStart()
        {
            Console.WriteLine("Bitwa!!!");
            Console.WriteLine();

            Console.WriteLine("Jesteś zmuszony stawić czoło przeciwnikom.");

            SelectWayDisplayDelay(i);
        }

        public static void BattleStats(Weapon weapon, Hero enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"broń zadaje [{weapon.Damage}] obrażeń.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Stan :");
            HeroColorText(enemy);
            Console.WriteLine($"Życie: {enemy.Life}");
            Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
            Console.WriteLine("");
            Console.WriteLine();

            SelectWayDisplayDelay(i);

        }

        public static void PresentationOfAttacker(Hero hero)
        {
       
            Weapon weapon = hero.Inventory[0] as Weapon;


            Console.WriteLine();
            Console.WriteLine("Atak !");
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.Write($"Kolej: ");
            HeroColorText(hero);
            Console.WriteLine($"Używa broni [{weapon.WeponName}]");
            Console.WriteLine($"O wytrzymałości [{ weapon.Hardness}]");
            Console.WriteLine($"Zadającej obrażenia na poziomie [{weapon.Damage}].");
            Console.WriteLine("==================================================================");
            Console.WriteLine();

            SelectWayDisplayDelay(0);

        }

        public static void PresentationEnemies(List<Hero> enemies)
        {
            int enemyNumber = 1;  
            foreach (Hero enemy in enemies)
            {
                Console.WriteLine(enemy.Name + " atakuj - " + enemyNumber);

                Console.WriteLine();
                Console.Write($"Stan wroga: ");
                HeroColorText(enemy);
                Console.WriteLine($"Życie: {enemy.Life}");
                Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
                Console.WriteLine("");
                Console.WriteLine();

                enemyNumber++;
                Console.WriteLine();

                SelectWayDisplayDelay(0);

            }
        }

        public static void NoWeapon()
        {
            Console.WriteLine();
            Console.WriteLine("Nie posiadasz żadnej broni, nie możesz atakowac! Atakuje ten kto ma broń");
            Console.WriteLine();
        }

        public static void VictoryInBattle()
        {
                Console.WriteLine("Zwycięstwo!");
        }

        public static void EndOfTheLevel()
        {
            Console.WriteLine();
            Console.WriteLine("Gratulacje, ukończyłeś poziom!");
        }

        public static void SimpleRoadSelection()
        {
            Console.Write("Wybierz drogę (1) lub (2): ");
        }

        //public static int ChooseYourWay(Hero hero)
        //{
        //    return hero.HeroDirection("Wybierz drogę (1) lub (2): ");
        //}

        public static void EndOfTheGame()
        {
            GraphicGameObjects.WriteLineSetCursorPosition(35, 11, "End of the game.");
            SelectWayDisplayDelay(2);
        }

        public static void BattleDurabilityDown(Hero hero)
        {
            Console.WriteLine();
            Console.Write("Wytrzynmałość bohatera");
            HeroColorText(hero);
            Console.WriteLine("W wyniku trudu jaki włożył w walkę spadła");
            Console.WriteLine($"i wynosi teraz {hero.Durability}, będzie odzyskiwał ją odpoczywając.");
            Console.WriteLine();

            SelectWayDisplayDelay(0);
        }

        public static void DurabilityDownZero(Hero hero)
        {
            Console.WriteLine();
            Console.Write("Bohater ");
            HeroColorText(hero);
            Console.WriteLine("Stacił wytrzymałość, brkuje mu sił, żeby atakować.");
            Console.WriteLine();
        }

        public static void HeroDurabilityRegeneration(Hero hero)
        {
            Console.WriteLine();
            Console.Write("Bohater");
            HeroColorText(hero);
            Console.WriteLine("Regeneruje swoją wytrzymałość.");
            Console.WriteLine();
        }

        public static void HeroCondition(Hero hero)
        {
            Console.WriteLine("Hero condition: ");
            Console.Write("Name " );
            HeroColorText(hero);
            Console.WriteLine("Life [{0}] ", hero.Life);
            Console.WriteLine("Durability [{0}] ", hero.Durability);
            

            for (int i = 0; i < hero.Inventory.Length; i++)
            {
                if (hero.Inventory[i] != null)
                {
                    Weapon weapon = hero.Inventory[i] as Weapon;
                    Console.WriteLine("Broń numer " + i + " " + weapon.WeponName);
                }
                else
                {
                    //Console.WriteLine("Broń numer: " + i + " Brak broni.");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static string DownloadingData()
        {
            Console.CursorSize = 100;
            string item = Console.ReadLine();
            Console.CursorSize = 10;
            return item;
        }

        public static void HeroColorText(Hero hero)
        {
            ConsoleColor currientColor = Console.ForegroundColor; 

            if (hero.HeroID == 1)
            {
                SetColor(ConsoleColor.Blue);
            }
            if (hero.HeroID == 2)
            {
                SetColor(ConsoleColor.Red);
            }
            if (hero.HeroID == 3)
            {
                SetColor(ConsoleColor.Yellow);
            }
            if (hero.HeroID == 4)
            {
                SetColor(ConsoleColor.Magenta);
            }
            Console.WriteLine(hero.Name);
            SetColor(currientColor);
        }

    } 
}
