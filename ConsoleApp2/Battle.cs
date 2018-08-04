using FirstFantazy.Player;
using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy
{
    public class Battle
    {
        public Battle(List<Hero> heroes, List<Hero> enemies)
        {
            int select,j = 0, i = 0; 

            foreach (Hero hero in enemies)
            {
                Console.WriteLine(hero.Name + "atakuj - " + i);
                i++;
            }

            select = Convert.ToInt16(Console.ReadLine());

            Weapon weapon = heroes[j].Inventory[0] as Weapon;
            enemies[select].Life - weapon.Damage; 
        }
    }
}
