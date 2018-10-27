﻿
using System;
using System.Collections.Generic;

using FirstFantazy_StoryText;
using FirstFantazy_Hero;
using FirstFantazy_Scene;
using FirstFantazy_Levels;

namespace FirstFantazy.Program
{
    class Program
    {
        static void Main(string[] args)
        {
         
            int difficulty, difficultyDurability;
            const int BuorX = 88, BuorY = 26;  //bfuer size
            const int WindowX = 88, WindowY = 26; //window size

            CreateScene.LoadGameWindow(0,WindowX,WindowY,BuorX,BuorY);

            Console.Title = "FirstFantazy";
            CreateScene.LoadScene("IntroScene");
            Console.Write("Give your hero name: ");
            string name = Console.ReadLine();

            #region GameDifficulty

            do
            {
                Console.WriteLine("                         ***");
                Console.WriteLine();
                Console.WriteLine("Select diffculty level: Low = [1] Normal = [2] Hard = [3]");
                Console.WriteLine();
                Console.WriteLine("                         ***");

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

            #endregion GameDifficulty

            Hero myHero = new Hero(name, difficulty, difficultyDurability, 1);

            Hero myHero2 = new Hero();

            Levels myLevels = new Levels();

            #region Levels

            myHero = myLevels.LoadLevel1(myHero);

            if (myHero.IsLife == true)
            {
               //myHero = myLevels.LoadLevel2(myHero);
            }
            if (myHero.IsLife == true)
            {
               // myHero = myLevels.LoadLevel3(myHero, myHero2);
            }
            if (myHero.IsLife == true)
            {
               // myHero = myLevels.LoadLevel4(myHero, myHero2); // Nie wiem, czy to jest dobrze zrobione?
            }
            else
            {
                StoryText.EndOfTheGame();
            }

            #endregion Levels

            Console.ReadKey();
        }
    }
}
