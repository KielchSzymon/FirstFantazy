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
            Console.WriteLine("Pochodznia oświetla nikłym blaskiem mroki kolejnej jaskini, " +
                "gdzieś w oddali słychać kapanie wody rozbryzgującej się na skale. " +
                "Twoja obecność przestraszyła nietoperze, które przeleciały ci nad gową uciekając  w mrok. " +
                "Przed sobą widzisz dwie drogi: jedna to pułka skalna ciągnąca się wzdłuż ściany jaskini (1), druga to ścieżka podążająca w dół (2).");
        }

        

        public static void RockShelfBend()
        {
            Console.WriteLine("Pułka skalna urywa się nagle i z dużą prędkością spadasz w dół, " +
                        "tracisz punkjty wytrzymałości, ale docierasz do wyjści z z jaskiń");
        }

        public static void DeathInTheHole()
        {
            Console.WriteLine("Droga w doł, którą podążasz nagle zapada się i trafiasz do głębokiego dołu, pomimo usilnych starań, " +
                        "nie potrafisz się wydostać i umierasz z pragnienia i głodu!");
        }
    }
}
