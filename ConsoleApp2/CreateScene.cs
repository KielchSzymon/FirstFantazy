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
            if(sceneNumber == "Level1EnterScene")
            {
                LoadEnterScene();
            }
            if(sceneNumber == "BeginScene")
            {
                LoadGameBeginScene();
            }
            if (sceneNumber == "Level1TorchScene")
            {
                LoadTorchScene();
            }
            if (sceneNumber == "Level3StickScene")
            {
                LoadStickScene();
            }
        }

        private static void LoadGameBeginScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            GraphicGameObjects.DrawFirstFantazyKeyboardText();

            //GraphicGameObjects.DrawSword(5, 0);
            //GraphicGameObjects.DrawTorch(10, 0);
            
            StoryText.SelectWayDisplayDelay(4);
            Console.Clear();
        }

        private static void LoadEnterScene()
        {
            Console.Clear();

            GraphicGameObjects.DrawCaveEnterV2(0, 0, "Enter 1");
            GraphicGameObjects.DrawCaveEnterV2(28, 0, "Enter 2");

        }

        private static void LoadTorchScene()
        {
            Console.Clear();

            GraphicGameObjects.DrawTorch(10, 0);
        }

        private static void LoadStickScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            GraphicGameObjects.DrawStick(20, 0);
            GraphicGameObjects.WriteLineSetCursorPosition(20, 22, "Stick");
            StoryText.SelectWayDisplayDelay(4);
            Console.Clear();
        }

        private static void SeparatorScene()
        {
            GraphicGameObjects.DrawSeparator(40, 0);
        }
    }
}
