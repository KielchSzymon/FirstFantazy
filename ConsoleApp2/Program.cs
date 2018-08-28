using FirstFantazy.Player;
using System;
using FirstFantazy.Levels;
using FirstFantazy; 
using System.Collections.Generic; 

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int difficulty, difficultyDurability = 0;

            MyMethods myMethods = new MyMethods();

            Console.Title = "FirstFantazy";

            Console.Write("Give your hero name: ");
            name = Console.ReadLine();

            #region GameDifficulty

            do
            {
                Console.WriteLine("                         ***");
                Console.WriteLine();
                Console.WriteLine("Select diffculty level: Low = [0] Normal = [1] Hard = [2]");
                Console.WriteLine();
                Console.WriteLine("                         ***");

                difficulty = Convert.ToInt16(myMethods.DownloadingData());
                Console.WriteLine();

                if (difficulty == 0)
                {
                    difficulty = 3;
                    difficultyDurability = 10;
                    break;
                }
                if (difficulty == 1)
                {
                    difficulty = 2;
                    difficultyDurability = 5;
                    break;
                }
                if (difficulty == 2)
                {
                    difficulty = 1;
                    difficultyDurability = 2;
                    break;
                }
                else
                {
                    Console.WriteLine("You made the wrong choice.");
                }

            } while (true);

            #endregion GameDifficulty

            #region PlayerAndLevelCreation

            Hero myHero = new Hero(name, difficulty, difficultyDurability);

            Hero myHero2 = new Hero();

            Levels myLevels = new Levels();

            #endregion PlayerAndLevelCreation

            #region Levels

            //myHero = myLevels.LoadLevel1(myHero);

            if (myHero.IsLife == true)
            {
               // myHero = myLevels.LoadLevel2(myHero);
            }
            if (myHero.IsLife == true)
            {
                myHero = myLevels.LoadLevel3(myHero, myHero2);
            }
            if (myHero.IsLife == true)
            {
                myHero = myLevels.LoadLevel4(myHero, myHero2);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("End of the game.");
                Console.WriteLine("Press any key to continue...");
            }

            #endregion Levels

            Console.ReadKey();
        }
    }
}
