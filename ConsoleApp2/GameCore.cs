using FirstFantazy_Hero;
using FirstFantazy_Levels;
using FirstFantazy_Scene;
using FirstFantazy.Story;
using FirstFantazy_StoryText;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace FirstFantazy.Core
{
    public class GameCore
    {
        Hero hero;
        Hero companion;
        Levels levels;
        ServiceProvider serviceProvider;

        public GameCore(ServiceProvider serviceProvider)
        {
            hero = new Hero();
            levels = new Levels();
            this.serviceProvider = serviceProvider;
        }

        public void StartCore()
        {
            const int BuorX = 88, BuorY = 26;  //bfuer size
            const int WindowX = 88, WindowY = 26; //window size

            CreateScene.LoadGameWindow(0, WindowX, WindowY, BuorX, BuorY);

            Console.Title = "FirstFantazy";
            //CreateScene.LoadScene("BeginScene");

            string name = SetYourName();

            hero = ChooseTheDifficultyLevelOfTheGame(name, hero);

            LoadLevel(1, serviceProvider);
        }
        
        private string SetYourName()
        {
            StoryText.GiveTheNameOfTheHero();
            string name = StoryText.GetInputValue();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = SetYourName();
            }

            return name;
        }

        private void LoadLevel(int levelNumber, ServiceProvider sp)
        {
            if (hero.IsLife)
            {
                switch (levelNumber)
                {
                    case 1:
                        hero = levels.LoadLevel1(hero, sp);
                        LoadLevel(2, sp);
                    break;
                    case 2:
                        hero = levels.LoadLevel2(hero);
                        LoadLevel(3, sp);
                    break;
                    case 3:
                        companion = new Hero();
                        hero = levels.LoadLevel3(hero, companion);
                        LoadLevel(4, sp);
                    break;
                    case 4:
                        hero = levels.LoadLevel4(hero, companion);
                        break;
                }
            }
            else
            {
                Console.Clear();
                StoryText.EndOfTheGame();
                StoryText.SelectWayDisplayDelay(4);
            }

        }

        public static Hero ChooseTheDifficultyLevelOfTheGame(string name, Hero hero)
        {
            int difficulty = 0, difficultyDurability;

            do
            {
                StoryText.SelectDiffcultyLevel();

                difficulty = GetInputValueHandlingExceptions(0, 1, 3);
 
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

            } while (true);

            return hero = new Hero(name, difficulty, difficultyDurability, 1);
        }

        public static int GetInputValueHandlingExceptions(int factor, int minValue, int maxValue)
        {
            int selectedValue = 0;

            try
            {
                selectedValue = Int16.Parse(StoryText.GetInputValue());
            }
            catch (FormatException ex)
            {
                BattleText.SelectValueHandlingExceptionsText(); 
                selectedValue = GetInputValueHandlingExceptions(factor, minValue, maxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (selectedValue > maxValue)
            {
                StoryText.EnterAValueFromTheMaximumToTheMinimumText(minValue, maxValue);
               selectedValue = GetInputValueHandlingExceptions(factor, minValue, maxValue);
            }
            if (selectedValue < minValue)
            {
                StoryText.EnterAValueFromTheMaximumToTheMinimumText(minValue, maxValue);
                selectedValue = GetInputValueHandlingExceptions(factor, minValue, maxValue);
            }

            return selectedValue - factor;
        }
    }
}
