
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;



namespace FirstFantazy_StoryText
{
    public class StoryText
    {
        private const int i = 0;

        public static void SelectWayDisplayDelay(int i)
        {
            if (i==0)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
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
                Thread.Sleep(3000);
            }
            if (i == 3)
            {
                Thread.Sleep(3000);
            }
            else
            {
                Thread.Sleep(3000);
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
            Console.WriteLine();

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

            SelectWayDisplayDelay(i);

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

                SelectWayDisplayDelay(1);

            }
        }

        public static void NoWeapon()
        {
            Console.WriteLine();
            Console.WriteLine("Nie posiadasz żadnej broni, nie możesz atakowac! Atakuje ten kto ma broń");
            Console.WriteLine();
        }

        public static void EndOfTheGame()
        {
            Console.WriteLine();
            Console.WriteLine("End of the game.");
            Console.WriteLine("Press any key to continue...");
        }

        public static void BattleDurabilityDown(Hero hero)
        {
            Console.WriteLine();
            Console.Write("Wytrzynmałość bohatera");
            HeroColorText(hero);
            Console.WriteLine("W wyniku trudu jaki włożył w walkę spadła");
            Console.WriteLine($"i wynosi teraz {hero.Durability}, będzie odzyskiwał ją odpoczywając.");
            Console.WriteLine();

            SelectWayDisplayDelay(i);
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
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("hero condition:");
            Console.Write("Name :" );
            HeroColorText(hero);
            Console.WriteLine("Life  [{0}]  Durability [{1}]", hero.Life, hero.Durability);
            

            for (int i = 0; i < hero.Inventory.Length; i++)
            {
                if (hero.Inventory[i] != null)
                {
                    Weapon weapon = hero.Inventory[i] as Weapon;
                    Console.WriteLine("Broń numer: " + i + " " + weapon.WeponName);
                }
                else
                {
                    //Console.WriteLine("Broń numer: " + i + " Brak broni.");
                }
            }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }

        public static string DownloadingData()
        {
            Console.WriteLine();
            Console.Write(">> ");
            string item = Console.ReadLine();
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
