using System;
using System.Collections.Generic;
using System.Text;
using FirstFantazy_Hero_Weapon;
using FirstFantazy_StoryText;
using FirstFantazy_Battle;
using FirstFantazy_Hero;

namespace FirstFantazy.Story
{
    class BattleText: StoryText
    {
        public static void OpponentDefeated()
        {
            Console.WriteLine("Przeciwnik pokonany:");
            Console.WriteLine();
        }

        public static void TheWeaponDoesNotHurt()
        {
            Console.WriteLine("Broń nie czyni krzywdy przeciwnikowi, za to traci 1 punkt wytrzymałości.");
        }
        
        public static void StateOfArms(Weapon weapon)
        {
            Console.WriteLine($"Po stracie punktu broń ma wytrzymałość: {weapon.Hardness}");
        }

        public static void WeaponDestroyed(Weapon weapon)
        {
            Console.WriteLine("Twoja broń {0}, uległa zniszczeniu!", weapon.WeponName);
        }

        public static void InformationWeaponDestroyed()
        {
            Console.WriteLine("Twoja broń uległa zniszczeniu, nie możesz atakowć");
            Console.WriteLine();
        }

        public static void HeroRandomAttack(List<Hero> heroes, List<Hero> enemies, int j, int selectedEnemy)
        {
            Console.WriteLine();
            Console.WriteLine($"{heroes[j].Name}, atkuje losowo wybranego przeciwnika {enemies[selectedEnemy].Name}");
            Console.WriteLine();
        }

        public static void RandomEnemyAttack(List<Hero> heroes, List<Hero> enemies, int j, int i)
        {
            Console.WriteLine();
            Console.WriteLine("Atakuje losowo przeciwnik " + enemies[i].Name);

            Console.WriteLine("Atkuje losowo bohatera " + heroes[j].Name);
            Console.WriteLine();
        }
    }
}
