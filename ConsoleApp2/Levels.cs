using FirstFantazy.Player;
using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;
using System.Text;



namespace FirstFantazy.Levels
{
    public  class Levels
    {

        #region Methods

        public Hero LoadLevel1(Hero hero)
        {

            int direction;

            TheBeginningOfTheLevel("1");

            hero.HeroCondition();

            #region BodyLevel

            Console.WriteLine("Budzisz się jedyne co pamiętasz to, że masz na imię {0}", hero.Name);
            Console.WriteLine();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Przed sobą widzisz dwie ścieżki, idziesz w (1) lewo lub (2) w prawo.");

                direction = Convert.ToInt16(Console.ReadLine());

                if (direction == 1)
                {
                    if (!hero.backPack.ContainsKey("items"))
                    {
                        Console.WriteLine("Giniesz! Nie widzisz gdzie idziesz i niestety potykasz się wpadając w rospadlinę.");
                        hero.IsLife = false;
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Console.WriteLine("Dzięki pochodni udaje Ci się przejść do kolejnej jaskini.");
                        Console.WriteLine();
                        Console.WriteLine("Gratulacje, ukończyłeś poziom!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        hero.LevelEnd = true;
                    }
                }
                else
                {
                    if (hero.backPack.Count == 0)
                    {
                        Console.WriteLine("Zanjdujesz palącą się pochodnię.");
                        hero.backPack["items"] = new List<object>();
                        hero.backPack["items"].Add("torch");
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Console.WriteLine("Tu już nic nie ma");
                    }
                }

                if (hero.Life == 0)
                {
                    hero.IsLife = false;
                }
            }
            while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel2(Hero hero)
        {

            TheBeginningOfTheLevel("2");

            hero.HeroCondition();
                
            #region BodyLevel

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

                    hero.LevelEnd = true;

                }
                else
                {
                    Console.WriteLine("Droga w doł, którą podążasz nagle zapada się i trafiasz do głębokiego dołu, pomimo usilnych starań, " +
                        "nie potrafisz się wydostać i umierasz z pragnienia i głodu!");
                    hero.IsLife = false;
                }
            } while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel3(Hero hero, Hero hero2)
        {

            TheBeginningOfTheLevel("3");
        
            hero.HeroCondition();

            #region BodyLevel

            do
            {
                if (hero.HeroDirection("Wybierz drogę (1) lub (2)") == 1)
                {
                    Console.WriteLine("Spotykasz bohatera o imieniu {0}, który rzuca ci kij z ostrzeżeniem. 'Uwaga nadchodzą!' ", hero2.Name);
                    Console.WriteLine();

                    hero.Inventory[0] = new Weapon(2, 15, 5, "Stick");

                    hero2.HeroCondition();

                    #region CreatingHeroesAndEnemies

                    List<Hero> heroes = new List<Hero>();

                    heroes.Add(hero);
                    heroes.Add(hero2);

                    List<Hero> enemy = new List<Hero>()
                    {
                        new Hero()
                        {
                            Durability = 10,
                            IsLife = true,
                            Name = "Ogr 1",
                            Life = 2,
                            Inventory = new Weapon[]{new Weapon(1, 5, 1, "Arm") }

                        },
                        new Hero()
                        {
                            Durability = 10,
                            IsLife = true,
                            Name = "Ogr 2",
                            Life = 2,
                            Inventory = new Weapon[]{new Weapon(1, 5, 1, "Arm") }

                        }
                    };

                    #endregion CreatingHeroesAndEnemies


                    Battle battle = new Battle(heroes, enemy);
                    heroes = battle.Initialize();
                    //warunke co robic jak wygrales lub przegrales zwracany z klasy bitwa
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Atakuje cię nieznany zwierz i giniesz!");
                    hero.IsLife = false;
                }
            } while (hero.IsLife && !hero.LevelEnd);

            return hero;

            #endregion BodyLevel

        }

        public Hero LoadLevel4(Hero hero, Hero hero2)
        {
            TheBeginningOfTheLevel("4");

            return hero;
        }

        public void TheBeginningOfTheLevel(string levelNumber)
        {
            string levelNumberText = levelNumber;

            Console.Title = "FirstFantazy Level" + levelNumberText;
            Console.Clear();
            Console.WriteLine("Level{0}", levelNumberText);
            Console.WriteLine();

        }

        #endregion Methods

    }
}
