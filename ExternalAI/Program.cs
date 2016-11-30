using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Threading;

namespace ExternalAI
{
    public static class Program
    {
        static InputSimulator input;
        static int defaultPressedDuration = 500;
        public static IDictionary<string, VirtualKeyCode> keyMap = new Dictionary<string, VirtualKeyCode>()
        {
            { "left", VirtualKeyCode.VK_A},
            { "right", VirtualKeyCode.VK_D},
            { "up", VirtualKeyCode.VK_W},
            { "down", VirtualKeyCode.VK_S}
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            input = new InputSimulator();

            Interpreter.AILoader("HardcodedAI.json");

            //Thread.Sleep(3000);
            //input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            //Thread.Sleep(2000);
            //input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
        }
        public static void press(List<VirtualKeyCode> keys, int millisecondsPressed)
        {
            keys.ForEach(k => input.Keyboard.KeyDown(k));
            Thread.Sleep(millisecondsPressed);
            keys.ForEach(k => input.Keyboard.KeyUp(k));
        }
        static void press(VirtualKeyCode k, int millisecondsPressed)
        {
            input.Keyboard.KeyDown(k);
            Thread.Sleep(millisecondsPressed);
            input.Keyboard.KeyUp(k); 
        }
        static void press(VirtualKeyCode k)
        {
            press(k, defaultPressedDuration);
        }
        public static void left(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_A, millisecondsPressed);
        }
        public static void left(VirtualKeyCode k)
        {
            left(defaultPressedDuration);
        }
        public static void right(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_D, millisecondsPressed);
        }
        public static void right(VirtualKeyCode k)
        {
            right(defaultPressedDuration);
        }
        public static void up(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_W, millisecondsPressed);
        }
        public static void up(VirtualKeyCode k)
        {
            up(defaultPressedDuration);
        }
        public static void down(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_S, millisecondsPressed);
        }
        public static void down(VirtualKeyCode k)
        {
            down(defaultPressedDuration);
        }
    }
}
