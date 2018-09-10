using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazyHero;

namespace FirstFantazyGameObject
{
    class GameObjeckt
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
