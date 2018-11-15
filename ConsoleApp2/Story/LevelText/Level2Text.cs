using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_StoryText;

namespace FirstFantazy.Story.LevelText
{
    class Level2Text: StoryText
    {
        public static void SelectTheUpOrDownPath()
        {
            Console.WriteLine("Pochodnia oświetla mroki kolejnej jaskini. ");
            Console.WriteLine("Przed sobą widzisz dwie drogi: ");
            Console.WriteLine(" - jedna to pułka skalna ciągnąca się wzdłuż ściany jaskini (1)");
            Console.WriteLine(" - druga to ścieżka podążająca w dół (2)");
        }

        public static void RockShelfBend()
        {
            Console.WriteLine("Pułka skalna urywa się, spadasz w dół.");
            Console.WriteLine("Tracisz punkjty wytrzymałości, ale docierasz do wyjścia.");
        }

        public static void DeathInTheHole()
        {
            Console.WriteLine("Droga, którą podążasz zapada się, trafiasz do głębokiego dołu.");
            Console.WriteLine("Nie potrafisz się wydostać, umierasz z pragnienia i głodu.");
        }
    }
}
