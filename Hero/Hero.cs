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
        public List<string> BackPack { get; set; }
        public Dictionary<string, List <object>> Inventory { get; set; }
        public int Strength { get; set;} 

        public Hero()
        {
            Name = "Edgar";
            Life = 100;
            Durability = 200;
            IsLife = true;
            LevelEnd = true;
            BackPack = new List<string>();
        } 

        public Hero(string Name, int life, int durability)
        {
           this.Name = Name;
            Life = life;
            Durability = durability;
            IsLife = true;
            LevelEnd = true;
            BackPack = new List<string>();
            Strength = 10;
            Inventory = new Dictionary<string, List<object>>();
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
