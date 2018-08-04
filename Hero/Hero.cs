using FirstFantazy.Player.Weapon;
using System;
using System.Collections.Generic;

namespace FirstFantazy.Player
{
    public class Hero
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = "Warrior " + value; }
        }
   
        public int Life { get; set; }
        public int Durability { get; set; }
        public bool IsLife { get; set; }
        public bool LevelEnd { get; set; }
        public object[] Inventory { get; set; }
        public int Strength { get; set;}
        public Dictionary<string, List<object>> backPack;

        public Hero()
        {
            Name = "Edgar";
            Life = 100;
            Durability = 200;
            IsLife = true;
            LevelEnd = true;
            Inventory = new object[] { new Weapon.Weapon(1, 5, 1, "Stick") };
            backPack = new Dictionary<string, List<object>>();
        } 

        public Hero(string Name, int life, int durability)
        {
           this.Name = Name;
            Life = life;
            Durability = durability;
            IsLife = true;
            LevelEnd = true;
            backPack = new Dictionary<string, List<object>>();
            Strength = 10;
            Inventory = new object[5];
        }

        public void HurtHero()
        {
            Durability--;
            if (Durability == 0)
            {
                Life--;
            } 
        }

        public void HeroCondition()
        {
            Console.WriteLine("hero condition:\nName : [{0}]  Life  [{1}]  Durability [{2}]", Name, Life, Durability);
        }

        public int HeroDirection(string messageForTheplayer)
        {
            int direction;

            Console.WriteLine();
            Console.WriteLine(messageForTheplayer);

            direction = Convert.ToInt16(Console.ReadLine());

            return direction;
        }
    }
}
