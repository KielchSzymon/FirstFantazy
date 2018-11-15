using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_StoryText;

namespace FirstFantazy.Story.LevelText
{
    class Level3Text: StoryText
    {
        public static void TwoExitsFromTheCave()
        {
            Console.WriteLine("Jaskinia się kończy, korytarz rozwidla w lewo (1) i w prwo (2).");
        }

        public static void MeetingOfACompanion(Hero hero2)
        {
            Console.WriteLine("Spotykasz bohatera o imieniu {0}.", hero2.Name);
            Console.WriteLine("Rzuca ci kij i krzyczy. 'Uwaga nadchodzą!' ");
        }

        public static void KilledByAnAnimal()
        {
            Console.WriteLine();
            Console.WriteLine("Atakuje cię nieznany zwierz. Giniesz!");
        }
    }
}
