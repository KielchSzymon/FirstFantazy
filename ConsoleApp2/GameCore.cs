using FirstFantazy_Hero;
using FirstFantazy_Levels;
using FirstFantazy_Scene;
using FirstFantazy_StoryText;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy
{
    public class GameCore
    {
        Hero hero;
        Hero companion;
        Levels levels;

        public GameCore()
        {
            hero = new Hero();
            levels = new Levels();
        }

        public void StartCore()
        {
            const int BuorX = 88, BuorY = 26;  //bfuer size
            const int WindowX = 88, WindowY = 26; //window size

            CreateScene.LoadGameWindow(0, WindowX, WindowY, BuorX, BuorY);

            Console.Title = "FirstFantazy";
            CreateScene.LoadScene("BeginScene");
            Console.Write("Give your hero name: ");
            string name = StoryText.DownloadingData();

            //extract code under to the new method 

            hero = ChooseTheDifficultyLevelOfTheGame(name, hero);

            LoadLevel(1);

            Console.ReadKey();
        }

        private void LoadLevel(int levelNumber)
        {
            if (hero.IsLife)
            {
                switch (levelNumber)
                {
                    case 1:
                        hero = levels.LoadLevel1(hero);
                        LoadLevel(2);
                    break;
                    case 2:
                        hero = levels.LoadLevel2(hero);
                        LoadLevel(3);
                    break;
                    case 3:
                        companion = new Hero();
                        hero = levels.LoadLevel3(hero, companion);
                        LoadLevel(4);
                    break;
                    case 4:
                        hero = levels.LoadLevel4(hero, companion);
                        break;
                }
            }
            else
            {
                StoryText.EndOfTheGame();
            }

        }

        public static Hero ChooseTheDifficultyLevelOfTheGame(string name, Hero hero)
        {
            int difficulty, difficultyDurability;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Select diffculty level: Low = [1] Normal = [2] Hard = [3]");
                Console.WriteLine();

                difficulty = Convert.ToInt16(StoryText.DownloadingData());
                Console.WriteLine();

                if (difficulty == 1)
                {
                    difficulty = 3;
                    difficultyDurability = 10;
                    break;
                }
                if (difficulty == 2)
                {
                    difficulty = 2;
                    difficultyDurability = 5;
                    break;
                }
                if (difficulty == 3)
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

            return hero = new Hero(name, difficulty, difficultyDurability, 1);
        }
    }
}
