
using System;
using System.Collections.Generic;

using FirstFantazy_StoryText;
using FirstFantazy_Hero;
using FirstFantazy_Scene;
using FirstFantazy_Levels;
using FirstFantazy.Core;

namespace FirstFantazy.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore core = new GameCore();

            core.StartCore();
           
        }
    }
}
