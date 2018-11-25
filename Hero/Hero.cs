using System;
using System.Collections.Generic;

using FirstFantazy_Hero_Weapon;

namespace FirstFantazy_Hero
{
    public class Hero
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = "." + value; }
        }

        public int Life { get; set; }
        public int Durability { get; set; }
        public bool IsLife { get; set; }
        public bool LevelEnd { get; set; }
        public object[] Inventory { get; set; }
        public int Strength { get; set; }

        public Dictionary<string, List<object>> backPack;

        public int HeroID;


        public Hero()
        {
            HeroID = 2;
            Name = "Edgar";
            Life = 2;
            Durability = 10;
            IsLife = true;
            LevelEnd = true;
            Inventory = new object[5];
            Inventory[0] = new Weapon(1, 5, 1, "Stick");
            backPack = new Dictionary<string, List<object>>(); 
        }  

        public Hero(string Name, int life, int durability, int heroID)
        {
            HeroID = heroID;
            this.Name = Name;
            Life = life;
            Durability = durability;
            IsLife = true;
            LevelEnd = false;
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
        
        public void HeroDurabilityDownUp(int durabilityDawnUp, int j)
        {
            if (j==0)
            {
                for (int i = 0; i < durabilityDawnUp; i++)
                {
                    Durability--;
                }
            }
            else
            {
                for (int i = 0; i < durabilityDawnUp; i++)
                {
                    Durability++;
                }
            }
            
        }

    }
}
