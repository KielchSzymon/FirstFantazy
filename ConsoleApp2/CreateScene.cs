using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace FirstFantazy.Scene
{
    public class CreateScene
    {
        public static void LoadScene(string sceneNumber)
        {
            if(sceneNumber == "Level1")
            {
                LoadFristScene();
            }

        }

        public static void LoadGameWindow()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

        }


        private static void LoadFristScene()
        {
            Console.Clear();

            drawDoor(Convert.ToInt16(Console.CursorLeft),Convert.ToInt16(Console.CursorTop));

            Console.WriteLine();
        }


        private static void drawDoor(int cursorX, int cursorY)
        {
            int endCursorPositionY;

            cursorY += 20;

            endCursorPositionY = cursorY;

            Console.SetCursorPosition(cursorX, cursorY);


            for (int i=0; i<20; i++)
            {
                Console.Write('*');
                cursorY--;
                cursorX++;

                Console.SetCursorPosition(cursorX, cursorY);
            }



            for (int i = 0; i < 10; i++)
            {
                Console.Write('@');
                cursorX++;

                Console.SetCursorPosition(cursorX, cursorY);
            }

            cursorY++;

            Console.SetCursorPosition(cursorX, cursorY);

            for (int i = 0; i < 20; i++)
            {
                Console.Write('*');
                cursorY++;
                cursorX++;

                Console.SetCursorPosition(cursorX, cursorY);
            }


            Console.SetCursorPosition(0, endCursorPositionY);
        }
    }
}
