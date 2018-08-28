using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy.Player.Weapon
{
    public class Weapon
    {
        #region ClassBoxes

        public int Range { get; set; }
        public int Hardness { get; set; }
        public int Damage { get; set; }
        public string WeponName { get; set; }

        public bool active;
        public List<string> MagicProperties;

        #endregion ClassBoxes

        #region Constructors

        public Weapon(int range, int hardness, int damage, string weaponName, List<string> magicP = null)
        {
            Range = range;
            Hardness = hardness;
            Damage = damage;
            MagicProperties = magicP;
            WeponName = weaponName;
        }

        #endregion Constructors

    }
}
