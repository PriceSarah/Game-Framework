using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace Game_Framework
{
    static class PlayerInput
    {

        private delegate void KeyEvent(int key);

        private static KeyEvent OnKeyPress;
        public static void AddKeyEvent(Event action, int key)
        {
            void keyPressed(int keyPress)
            {
                if (key == keyPress)
                {
                    action();
                }
            }

            OnKeyPress += keyPressed;
        }

        public static void ReadKey()
        {
            //ConsoleKey inputKey = Console.ReadKey().Key;
            int inputKey = RL.GetKeyPressed();
            OnKeyPress(inputKey);
        }
    }
}
