using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_StoryText;

namespace FirstFantazy.Story.LevelText
{
    class Level4Text: StoryText
    {
        public static void AfterTheVictoriousBattleWithOgres()
        {
            Console.WriteLine("Bitwa wygrana, ocaliliście życie. Teraz trzeba obszukać wrogów, zobaczyć czy nie mają czegoś cennego.");
            Console.WriteLine("A potem ukryć się czym prędzej, znaleźdż jakieś miejsce na odpoczynek.");
            Console.WriteLine();
            Console.WriteLine("Znajdujecie miejsce na odpoczynek, rozpalacie ognisko, to pozwala zregenerować wytrzymałoś." +
                " Niestety przy wrogach nic nie było.");
            Console.WriteLine();

            Console.WriteLine("Ukrywacie się w pobliskiej rozpadlinie skalnej, u podnóża gory. Rozpalacie ognisko.");
            Console.WriteLine("Odzyskujecie utraconą wytrzymałość, każyd z was po 10 puktów");
            Console.WriteLine();
        }

        public static void FindingASword()
        {
            Console.WriteLine("Rozpadlina skalna, w której się ukryliście okazuje się grobem kilkunastu rycerzy, z uzbrojenia, " +
            " które tam odnaleźliście bierzecie po mieczu.");
        }
    }
}
