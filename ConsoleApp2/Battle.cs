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

            Console.WriteLine("Jesteś zmuszony stawić czoło przeciwnikom");

            do
            {
                i = 0;


                Console.WriteLine($"Kolej gracza {heroes[j].Name}");

                foreach (Hero hero in enemies)
                {
                    Console.WriteLine(hero.Name + "atakuj - " + i);
                    i++;
                }

                select = Convert.ToInt16(Console.ReadLine());

                Weapon weapon = heroes[j].Inventory[0] as Weapon;

                // jak brak broni to pomin atak dla danego gracza

                Hero enemy = enemies[select];

                if (enemy.Durability < weapon.Hardness)
                {
                    enemy.Life -= weapon.Damage;

                    Console.WriteLine($"twoja broń zadaje {weapon.Damage}");

                    if (enemy.Life <= 0)
                    {
                        enemy.IsLife = false;
                        Console.WriteLine("Pokonujesz 1 wroga");
                    }
                }else
                {
                    Console.WriteLine("twoja broń nie czyni krzywdy przeciwnikowi za to traci 1 punkt wytrzymałości");

                    //jak wytrzymalosc broni spada ponizej zera usun bron
                   // heroes[j].Inventory[0] = null;
                }


                if(!enemy.IsLife)
                {
                    enemies.Remove(enemy);
                }


                //dodaj ataki przeciwnikow
                //a tutaj jak maja atakowac po pierwszym graczu

                if(j <1)
                {
                    //a tutaj jak maja atakowac na zmiane
                    j++;
                }
                else
                {
                    //tu moze byc przykladowo etap ataku przecinikow jak maja atakowac bo graczach
                    j = 0;
                }


            } while (enemies.Count > 0);



        }
    }
}
