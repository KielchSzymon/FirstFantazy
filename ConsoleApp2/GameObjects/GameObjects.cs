using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_Hero;

namespace FirstFantazy_GameObject
{
    class GameObject
    {
        public void Campfire(int durabilityWorth, Hero actualDurability)
        {
            for (int i = 0; i < durabilityWorth; i++)
            {
                actualDurability.Durability++;
            }
        }
    }
}
