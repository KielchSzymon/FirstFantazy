using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy.Player.Weapon
{
    public class Stick
    {
        public int Range { get; set; }
        public int Hardness { get; set; }
        public int Damage { get; set; }

        public bool active;
        public List<string> MagicProperties;

        public Stick(int range, int hardness, int damage, List<string> magicP = null)
        {
            Range = range;
            Hardness = hardness;
            Damage = damage;
            MagicProperties = magicP;
        }
    }
}
