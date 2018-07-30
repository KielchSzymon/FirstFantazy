using System;
using System.Collections.Generic;
using System.Text;
using FirstFantazy.Player.Weapon;
using FirstFantazy.Player;

namespace FirstFantazy.Levels
{
    public  class Levels
    {

        
        public Hero LoadLevel1(Hero hero)
        {

            int direction;

            Console.Title = "FirstFantazy Level1";
            Console.Clear();
            Console.WriteLine("Level1");
            Console.WriteLine();
            Console.WriteLine("Budzisz się jedyne co pamiętasz to, że masz na imię {0}", hero.Name);
            Console.WriteLine();

            do
            {
                hero.HeroCondition();
                Console.WriteLine();
                Console.WriteLine("Przed sobą widzisz dwie ścieżki, idziesz w (1) lewo lub (2) w prawo.");

                direction = Convert.ToInt16(Console.ReadLine());

                if (direction == 1)
                {
                    if (hero.BackPack.Count == 0)
                    {
                        Console.WriteLine("Giniesz! Nie widzisz gdzie idziesz i niestety potykasz się wpadając w rospadlinę.");
                        hero.IsLife = false;
                    }
                    else
                    {
                        Console.WriteLine("Dzięki pochodni udaje Ci się przejść do kolejnej jaskini.");
                        Console.WriteLine();
                        Console.WriteLine("Gratulacje, ukończyłeś poziom!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        hero.LevelEnd = false;
                    }
                }
                else
                {
                    if (hero.BackPack.Count == 0)
                    {
                        Console.WriteLine("Zanjdujesz palącą się pochodnię.");
                        hero.BackPack.Add("torch");
                    }
                    else
                    {
                        Console.WriteLine("Mając pochodnie, widzisz drogę. Przeciskasz się przez sczelinę i docierasz do drugiej jaskini");
                        Console.WriteLine();
                        Console.WriteLine("Gratulacje, ukończyłeś poziom!");
                        Console.ReadKey();
                        hero.LevelEnd = false;
                    }
                }

                if (hero.Life == 0)
                {
                    hero.IsLife = false;
                }
            }
            while (hero.IsLife && hero.LevelEnd);

            return hero;
        }

        public Hero LoadLevel2(Hero hero)
        {

            Console.Title = "FirstFantazy Level2";
            Console.Clear();
            Console.WriteLine("Level2");
            Console.WriteLine();
            Console.WriteLine();
            hero.HeroCondition();


            Console.WriteLine("Pochodznia oświetla nikłym blaskiem mroki kolejnej jaskini, " +
                "gdzieś w oddali słychać kapanie wody rozbryzgującej się na skale. " +
                "Twoja obecność przestraszyła nietoperze, które przeleciały ci nad gową uciekając  w mrok. " +
                "Przed sobą widzisz dwie drogi: jedna to pułka skalna ciągnąca się wzdłuż ściany jaskini (1), druga to ścieżka podążająca w dół (2).");
            do
            {
                if (hero.HeroDirection("Wybierz drogę (1) lub (2): ") == 1)
                {
                    Console.WriteLine("Pułka skalna urywa się nagle i z dużą prędkością spadasz w dół, " +
                        "tracisz punkjty wytrzymałości, ale docierasz do wyjści z z jaskiń");

                    hero.HurtHero();

                    Console.WriteLine();
                    Console.WriteLine("Gratulacje, ukończyłeś poziom!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    hero.LevelEnd = false;

                }
                else
                {
                    Console.WriteLine("Droga w doł, którą podążasz nagle zapada się i trafiasz do głębokiego dołu, pomimo usilnych starań, " +
                        "nie potrafisz się wydostać i umierasz z pragnienia i głodu!");
                    hero.IsLife = false;
                }
            } while (hero.IsLife && hero.LevelEnd);

            return hero;
        }

        public Hero LoadLevel3(Hero hero, Hero hero2)
        {
            Console.Title = "FirstFantazy Level3";
            Console.Clear();
            Console.WriteLine("Level3");
            Console.WriteLine();
            Console.WriteLine();
            hero.HeroCondition();

            do
            {
                if(hero.HeroDirection("Wybierz drogę (1) lub (2)") == 1)
                {
                    Console.WriteLine( "Spotykasz bohatera numer 2, który rzuca ci kij z ostrzeżeniem uwaga nadchodzą!");
                    hero.Inventory["Stick"] = new List<object>();
                    hero.Inventory["Stick"].Add(new Stick(2, 15, 1));

                    var weapon = hero.Inventory["Stick"];
                    hero2.HeroCondition();
                }
                else
                {
                    Console.WriteLine("Atakuje cię nieznany zwierz i giniesz!");
                    hero.IsLife = false;
                }
            } while (hero.IsLife && hero.LevelEnd);

            return hero;
        }
    }
}
