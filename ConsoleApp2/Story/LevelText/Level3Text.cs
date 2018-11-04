using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_Hero;
using FirstFantazy_StoryText;

namespace FirstFantazy.Story.LevelText
{
    class Level3Text: StoryText
    {
        public static void MeetingOfACompanion(Hero hero2)
        {
            Console.WriteLine("Spotykasz bohatera o imieniu {0}, który rzuca ci kij z ostrzeżeniem. 'Uwaga nadchodzą!' ", hero2.Name);
            Console.WriteLine();
        }

        public static void KilledByAnAnimal()
        {
            Console.WriteLine();
            Console.WriteLine("Atakuje cię nieznany zwierz i giniesz!");
        }
    }
}
