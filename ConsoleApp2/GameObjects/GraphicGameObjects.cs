using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantazy_Graphic_Game_Objects
{
    class GraphicGameObjects
    {
        public static void DrawFirstFantazyKeyboardText()
        {
            Console.WriteLine( " ____  ____  ____  ____  ____  ______________  ____  ____  ____  ____  ____  ____  ___" );
            Console.WriteLine( "||F ||||i ||||r ||||s ||||t ||||           ||||F ||||a ||||n ||||t ||||a ||||z ||||y ||");
            Console.WriteLine( "||__||||__||||__||||__||||__||||___________||||__||||__||||__||||__||||__||||__||||__||");
            Console.WriteLine(@"|/__\||/__\||/__\||/__\||/__\||/___________\||/__\||/__\||/__\||/__\||/__\||/__\||/__\|");
        }

        public static void DrawCaveEnterV1(int cursorX, int cursorY, string enterName )
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
        
        public static void DrawCaveEnterV2(int cursorX, int cursorY,  string enterName)
        {

            DrawingLoop(cursorX, cursorY, 2, 0, 26, 0, "++", "++", "cursorX", "cursorY++", "*");

            DrawingLoop(cursorX + 3, cursorY + 2, 5, 0, 0, 4, "++", "--/1", "cursorX", "cursorY++", "*");
            DrawingLoop(cursorX + 19, cursorY + 2, 5, 0, 0, 4, "++", "--/1", "cursorX++", "cursorY++", "*");


            DrawingLoop(cursorX, cursorY, 20, 0, 3, 0, "++", "++", "cursorX", "cursorY++", "*");
            DrawingLoop(cursorX+23, cursorY, 20, 0, 3, 0, "++", "++", "cursorX", "cursorY++", "*");

            WriteLineSetCursorPosition(cursorX+10, cursorY+19, enterName);
            
        }

        public static void DrawSword(int cursorX, int cursorY)
        {
            WriteLineSetCursorPosition(cursorX, cursorY,   @" /\");
            WriteLineSetCursorPosition(cursorX, cursorY+1, @"/  \");
            cursorY +=2;

            cursorY = DrawSwordFirebrand(cursorX, cursorY, 12);

            WriteLineSetCursorPosition(cursorX-3, cursorY,     " __|  |__");
            WriteLineSetCursorPosition(cursorX - 3, cursorY+1, "|________|");
            cursorY += 1;

            DrawHandle(cursorX, cursorY);
          
        }
        public static void DrawTorch(int cursorX, int cursorY)
        {
            DrawingLoop(cursorX, cursorY,     5, 0, 4, 0, "++", "++/1", "cursorX", "cursorY++", "x");

            DrawingLoop(cursorX, cursorY+5,   5, 0, 0, 4, "++", "--/1", "cursorX", "cursorY++", "x");

            DrawingLoop(cursorX, cursorY,     5, 0, 0, 0, "++", "++/1", "cursorX--", "cursorY++", "x");

            DrawingLoop(cursorX-4, cursorY+5, 5, 0, 0, 4, "++", "--/1", "cursorX++", "cursorY++", "x");

            cursorY = DrawSwordFirebrand(cursorX - 2, cursorY + 8, 5);
            DrawHandle(cursorX - 2, cursorY - 1);
        }
        public static void DrawStick(int cursorX,int cursorY)
        {
            int endCursorPositionX;
            int endCursorPositionY;

            WriteLineSetCursorPosition(cursorX+1, cursorY, "__");
            WriteLineSetCursorPosition(cursorX, cursorY + 1, "[  ]");

            cursorY = DrawSwordFirebrand(cursorX, cursorY+2, 18);

            WriteLineSetCursorPosition(cursorX, cursorY, "[  ]");
            WriteLineSetCursorPosition(cursorX+1, cursorY, "__");

            endCursorPositionX = cursorX - 1;
            endCursorPositionY = cursorY;

            WriteLineSetCursorPosition(cursorX-1, cursorY-5, "[");
            WriteLineSetCursorPosition(cursorX + 4, cursorY - 12, "]");
            WriteLineSetCursorPosition(cursorX + 3, cursorY - 3, "]");

            Console.SetCursorPosition(endCursorPositionX, endCursorPositionY);
        }

        #region Loop

        #region ElemetsLoop 
        public static void DrawHandle(int cursorX, int cursorY)
        {
            for (int k = 0; k < 5; k++)
            {
                cursorY++;
                WriteLineSetCursorPosition(cursorX, cursorY, "[  ]");
            }

            WriteLineSetCursorPosition(cursorX, cursorY, "[__]");
        }
        public static int DrawSwordFirebrand(int cursorX, int cursorY, int loopCounter)
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
        #endregion Elements

        public static void WriteLineSetCursorPosition(int cursorX, int cursorY, string _string)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine(_string);
        }

        public static void DrawingLoop(int cursorX, int cursorY, int externalLoopCounter, int externalLoopStartCounter, int innerLoopCounter, int innerLoopStartCounter, string typeOfExternalLoop, string typeOfinnerLoop, string cursorXReturnOption, string cursorYReturnOption, string typeOfsign)
        {
            Console.SetCursorPosition(cursorX, cursorY);

            switch (typeOfExternalLoop)
            {
                case "++":

                    for (int i = externalLoopStartCounter; i < externalLoopCounter; i++)
                    {

                        InnerLoop(innerLoopCounter, innerLoopStartCounter, i, typeOfinnerLoop, typeOfsign);

                        cursorX = CursorXReturnMetod(cursorX, cursorXReturnOption);
                        cursorY = CursorYReturnMetod(cursorY, cursorYReturnOption);

                        Console.SetCursorPosition(cursorX, cursorY);
                    }

                    break;
                case "--":

                    for (int i = externalLoopStartCounter; i < externalLoopCounter; i--)
                    {

                        InnerLoop(innerLoopCounter, innerLoopStartCounter,i , typeOfinnerLoop, typeOfsign);

                        cursorX = CursorXReturnMetod(cursorX, cursorXReturnOption);
                        cursorY = CursorYReturnMetod(cursorY, cursorYReturnOption);

                        Console.SetCursorPosition(cursorX, cursorY);
                    }

                    break;
            }

        }
        
        public static int CursorXReturnMetod(int cursorX, string cursorXReturnOption)
        {
            switch (cursorXReturnOption)
            {
                case "cursorX++":
                    cursorX++;
                    break;
                case "cursorX--":
                    cursorX--;
                    break;
                default:
                    cursorX = cursorX;
                    break;
            }

            return cursorX;
        }
        public static int CursorYReturnMetod(int cursorY, string cursorYReturnOption)
        {
            switch (cursorYReturnOption)
            {
                case "cursorY++":
                    cursorY++;
                    break;
                case "cursorY--":
                    cursorY--;
                    break;
                default:
                    cursorY = cursorY;
                    break;
            }

            return cursorY;
        }

        public static void InnerLoop(int innerLoopCounter, int innerLoopStartCounter, int actualExternalLoopCounterForInnerLoop , string typeOfInnerLoop, string typeOfsign)
        {
            switch (typeOfInnerLoop)
            {
                case "++":

                    for (int j = innerLoopStartCounter; j < innerLoopCounter; j++)
                    {
                        Console.Write(typeOfsign);

                    }

                    break;
                case "--":

                    for (int j = innerLoopStartCounter; j > innerLoopCounter; j--)
                    {
                        Console.Write(typeOfsign);
                    }
                    break;

                case "++/1":

                    for (int j = innerLoopStartCounter; j < actualExternalLoopCounterForInnerLoop; j++)
                    {
                        Console.Write(typeOfsign);

                    }

                    break;

                case "--/1":

                    for (int j = innerLoopStartCounter; j > actualExternalLoopCounterForInnerLoop; j--)
                    {
                        Console.Write(typeOfsign);

                    }

                    break;
            }
        }

        #endregion Loop
    }
}
