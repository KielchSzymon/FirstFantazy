
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
                Thread.Sleep(300);
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
        }

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        public static void GiveTheNameOfTheHero()
        {
            Console.Write("Podaj imię swojego boatera: ");
        }

        public static void SelectDiffcultyLevel()
        {
            Console.WriteLine();
            Console.Write("Wybierz poziom trudności: łatwy [1] normalny [2] trudny [3]: ");
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

        public static string GetInputValue()
        {
            Console.CursorSize = 100;
            string item = Console.ReadLine();
            Console.CursorSize = 10;
            return item;
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
                    Console.WriteLine("Broń numer " + i+1 + " " + weapon.WeponName);
                }
                else
                {
                    //Console.WriteLine("Broń numer: " + i + " Brak broni.");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
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

        public static void HeroDurabilityRegeneration(Hero hero)
        {
            Console.WriteLine();
            Console.Write("Bohater");
            HeroColorText(hero);
            Console.WriteLine("Regeneruje swoją wytrzymałość.");
            Console.WriteLine();
        }

        public static void EndOfTheGame()
        {
            GraphicGameObjects.WriteLineSetCursorPosition(35, 11, "End of the game.");
            SelectWayDisplayDelay(2);
        }

        public static void EnterAValueFromTheMaximumToTheMinimumText(int minValue, int maxValue)
        {
            Console.WriteLine();
            Console.Write("Podaj wartość liczbową z przedziłau od " + minValue + " do " + maxValue + ".  ");
        }
    } 
}
