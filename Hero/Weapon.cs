using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy_Hero_Weapon
{
    public class Weapon
    {
        public int Range { get; set; }
        public int Hardness { get; set; }
        public int Damage { get; set; }
        public string WeponName { get; set; }

        public bool active;
        public List<string> MagicProperties;

        public Weapon(int range, int hardness, int damage, string weaponName, List<string> magicP = null)
        {
            Range = range;
            Hardness = hardness;
            Damage = damage;
            MagicProperties = magicP;
            WeponName = weaponName;
        }
    }
}
