using FirstFantazy.Player;
using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FirstFantazy.Story
{
    public static class StoryText
    {

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        public static void BattleStart()
        {
            Console.WriteLine("Bitwa!!!");
            Console.WriteLine();

            Console.WriteLine("Jesteś zmuszony stawić czoło przeciwnikom.");
            Console.WriteLine();

            Thread.Sleep(3000);
        }

        public static void BattleStats(Weapon weapon, Hero enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"broń zadaje [{weapon.Damage}] obrażeń.");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine($"Stan : {enemy.Name} ");
            Console.WriteLine($"Życie: {enemy.Life}");
            Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
            Console.WriteLine("");
            Console.WriteLine();

            Thread.Sleep(3000);

        }

        public static void PresentationOfAttacker(Hero hero)
        {
       
            Weapon weapon = hero.Inventory[0] as Weapon;


            Console.WriteLine();
            Console.WriteLine("Atak !");
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine($"Kolej  [{hero.Name}]");
            Console.WriteLine($"Używa broni [{weapon.WeponName}]");
            Console.WriteLine($"O wytrzymałości [{ weapon.Hardness}]");
            Console.WriteLine($"Zadającej obrażenia na poziomie [{weapon.Damage}].");
            Console.WriteLine("==================================================================");
            Console.WriteLine();

            Thread.Sleep(2000);

        }

        public static void PresentationEnemies(List<Hero> enemies)
        {
            int enemyNumber = 1;  
            foreach (Hero enemy in enemies)
            {
                Console.WriteLine(enemy.Name + " atakuj - " + enemyNumber); 

                Console.WriteLine();
                Console.WriteLine($"Stan wroga: {enemy.Name} ");
                Console.WriteLine($"Życie: {enemy.Life}");
                Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
                Console.WriteLine("");
                Console.WriteLine();

                enemyNumber++;
                Console.WriteLine();

                Thread.Sleep(3000);

            }
        }
    }
}
