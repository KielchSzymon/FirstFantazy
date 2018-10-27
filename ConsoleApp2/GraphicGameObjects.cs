using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy_Graphic_Game_Objects
{
    class GraphicGameObjects
    {
        public static void DrawIntro()
        {
            Console.WriteLine( " ____  ____  ____  ____  ____  ______________  ____  ____  ____  ____  ____  ____  ___" );
            Console.WriteLine( "||F ||||i ||||r ||||s ||||t ||||           ||||F ||||a ||||n ||||t ||||a ||||z ||||y ||");
            Console.WriteLine( "||__||||__||||__||||__||||__||||___________||||__||||__||||__||||__||||__||||__||||__||");
            Console.WriteLine(@"|/__\||/__\||/__\||/__\||/__\||/___________\||/__\||/__\||/__\||/__\||/__\||/__\||/__\|");
        }
        public static void DrawEnterVer1(int cursorX, int cursorY, string enterName )
        {
            int endCursorPositionY;

            cursorY += 10;

            endCursorPositionY = cursorY;

            Console.SetCursorPosition(cursorX, cursorY);


            for (int i = 0; i < 10; i++)
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

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                cursorY++;
                cursorX++;

                Console.SetCursorPosition(cursorX, cursorY);
            }

            Console.SetCursorPosition(cursorX -18, cursorY);
            Console.WriteLine(enterName);

            Console.SetCursorPosition(0, endCursorPositionY+1);
        }
        public static void DrawEnterVer2(int cursorX, int cursorY, int lengthX, int hightY,  string enterName)
        {
            int endCursorPositionX;
            int endCursorPositionY;

            Console.SetCursorPosition(cursorX, cursorY);

            endCursorPositionX = cursorX;
            endCursorPositionY = cursorY;

            for (int j = 0; j < 7; j++)
            {
                cursorX = endCursorPositionX;

                for (int i = 0; i < 25; i++)
                {
                    Console.Write("*");
                    cursorX++;

                    Console.SetCursorPosition(cursorX, cursorY);
                }
                cursorY++;
            
               Console.SetCursorPosition(endCursorPositionX, cursorY);
            }


            for (int k = 0; k < 7; k++)
            {
                cursorX = endCursorPositionX;

                for (int i = 0; i < 25; i++)
                {
                    Console.Write("0");
                    cursorX++;

                    Console.SetCursorPosition(cursorX, cursorY);
                }
                cursorY++;

                Console.SetCursorPosition(endCursorPositionX, cursorY);
            }
        }
        public static void DrawSword(int cursorX, int cursorY)
        {
            WriteLineSetCursorPosition(cursorX, cursorY,   @" /\");
            WriteLineSetCursorPosition(cursorX, cursorY+1, @"/  \");
            cursorY +=2;

            cursorY = DrawBlade(cursorX, cursorY, 12);

            WriteLineSetCursorPosition(cursorX-3, cursorY,     " __|  |__");
            WriteLineSetCursorPosition(cursorX - 3, cursorY+1, "|________|");
            cursorY += 1;

            DrawHandle(cursorX, cursorY);
          
        }
        public static void DrawTorch(int cursorX, int cursorY)
        {
            int endCursorPositionX;
            int endCursorPositionY;

            endCursorPositionX = cursorX;
            endCursorPositionY = cursorY;

            Console.SetCursorPosition(cursorX, cursorY);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("x");
                }

                cursorX--;
                cursorY++;

                Console.SetCursorPosition(cursorX, cursorY);
            }

            Console.SetCursorPosition(cursorX+1, cursorY);

            for (int i = 0; i < 5; i++)
            {

                for (int j = 4; j > i; j--)
                {
                    Console.Write("x");
                }
                
                cursorX++;
                cursorY++;

                Console.SetCursorPosition(cursorX+1, cursorY);

            }

            cursorX = endCursorPositionX;
            cursorY = endCursorPositionY;

            for (int i = 0; i < 5; i++)
            {
                
                for (int j = 0; j < i; j++)
                {
                    Console.Write("x");
                }

                
                cursorY++;

                Console.SetCursorPosition(cursorX, cursorY);

            }

            for (int i = 0; i < 5; i++)
            {

                for (int j = 4; j > i; j--)
                {
                    Console.Write("x");
                }

                cursorY++;

                Console.SetCursorPosition(cursorX, cursorY);
            }

            cursorX -= 2;

            cursorY = DrawBlade(cursorX, cursorY-2, 5);
            DrawHandle(cursorX, cursorY-2);

        }
        public static void DrawStick(int cursorX,int cursorY)
        {
            int endCursorPositionX;
            int endCursorPositionY;

            WriteLineSetCursorPosition(cursorX+1, cursorY, "__");
            WriteLineSetCursorPosition(cursorX, cursorY + 1, "[  ]");

            cursorY = DrawBlade(cursorX, cursorY+2, 18);

            WriteLineSetCursorPosition(cursorX, cursorY, "[  ]");
            WriteLineSetCursorPosition(cursorX+1, cursorY, "__");

            endCursorPositionX = cursorX - 1;
            endCursorPositionY = cursorY;

            WriteLineSetCursorPosition(cursorX-1, cursorY-5, "[");
            WriteLineSetCursorPosition(cursorX + 4, cursorY - 12, "]");
            WriteLineSetCursorPosition(cursorX + 3, cursorY - 3, "]");
            Console.SetCursorPosition(endCursorPositionX, endCursorPositionY);
        }
        public static void WriteLineSetCursorPosition(int cursorX, int cursorY, string _string)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine(_string);
        }
        public static void DrawHandle(int cursorX, int cursorY)
        {
            for (int k = 0; k < 5; k++)
            {
                cursorY++;
                WriteLineSetCursorPosition(cursorX, cursorY, "[  ]");
            }

            WriteLineSetCursorPosition(cursorX, cursorY, "[__]");
        }
        public static int DrawBlade(int cursorX, int cursorY, int loopCounter)
        {
            int endCursorPositionY;

            for (int j = 0; j < loopCounter; j++)
            {
                WriteLineSetCursorPosition(cursorX, cursorY, "|  |");
                cursorY++;

                Console.SetCursorPosition(cursorX, cursorY);
            }

            endCursorPositionY = cursorY;

            return endCursorPositionY;
        }
    }
}
