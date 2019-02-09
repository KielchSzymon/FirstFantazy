using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_StoryText;
using Microsoft.Extensions.DependencyInjection;
using RepositoryCommon;

namespace FirstFantazy.Story.LevelText
{
    class Level1Text: StoryText
    {
        IRepositoryLevelText repo;

        public Level1Text(IRepositoryLevelText repository)
        {
            repo = repository;
        }

        public void WackeUp(Hero hero)
        {
            string levelText = repo.GetLevelText(0, 1);

            Console.WriteLine(levelText, hero.Name);
            Console.WriteLine();
        }

        public static void ChooseYourWay()
        {
            Console.WriteLine();
            Console.Write("Przed sobą widzisz dwa wejścia, idziesz w (1) lewo lub (2) w prawo. ");
        }

        public static void YouAreDeadInTheCleft()
        {
            Console.WriteLine("Giniesz! Nie widzisz gdzie idziesz i niestety potykasz się wpadając w rospadlinę.");
        }

        public static void YouEndTheLevelWithTheTorch()
        {
            Console.WriteLine("Dzięki pochodni udaje Ci się przejść do kolejnej jaskini.");
            Console.WriteLine("Gratulacje, ukończyłeś poziom!");
        }

        public static void YouFoundATorch()
        {
            Console.WriteLine("Zanjdujesz palącą się pochodnię.");
        }

        public static void ThereIsNothingHere()
        {
            Console.WriteLine("Tu już nic nie ma.");
        }

        public static void TheSamePlace()
        {
            Console.WriteLine();
            Console.WriteLine("Ponownie wracasza w to samo miejsce.");
        }


    }
}
