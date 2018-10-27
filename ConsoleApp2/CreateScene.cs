using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using FirstFantazy_Graphic_Game_Objects;
using FirstFantazy_StoryText;

namespace FirstFantazy_Scene
{
    public class CreateScene
    {
        public static void LoadGameWindow(int diagnosticSwitch, int wx, int wy, int bx, int by)
        {
            if (diagnosticSwitch == 1)
            {
                Console.SetBufferSize(bx,by);
                
                Console.SetWindowSize(wx, wy);
                Console.WriteLine("Okno         - szerokość: " + wx + " - wysokość: " + wy);
                Console.WriteLine();

                Console.WriteLine("Bufor ekranu - szerokość: " + bx + " - wysokość: " + by);
                StoryText.SelectWayDisplayDelay(0);
            }
            else
            {
                Console.SetWindowSize(wx, wy);
                Console.SetBufferSize(bx,by);
            }

        }

        public static void LoadScene(string sceneNumber)
        {
            if(sceneNumber == "Level1")
            {
                LoadFristScene();
            }
            if(sceneNumber == "IntroScene")
            {
                LoadIntroScene();
            }
        }

        private static void LoadIntroScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            //GraphicGameObjects.DrawIntro();
            //GraphicGameObjects.DrawSword(5, 0);
            GraphicGameObjects.DrawTorch(20, 0);
            //GraphicGameObjects.DrawStick(20, 0);
            //GraphicGameObjects.DrawEnterVer2(0,0,5,5,"1");
            StoryText.SelectWayDisplayDelay(0);
            Console.Clear();
        }

        private static void LoadFristScene()
        {
            Console.Clear();

            GraphicGameObjects.DrawEnterVer1(Convert.ToInt16(Console.CursorLeft),Convert.ToInt16(Console.CursorTop+2), "Enter1");
            GraphicGameObjects.DrawEnterVer1(50, 2, "Enter2");

            Console.WriteLine();
        }

    }
}
