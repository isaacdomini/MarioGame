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
    static class Program
    {
        static InputSimulator input;
        static int defaultPressedDuration = 500;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            input = new InputSimulator();
            Thread.Sleep(3000);
            input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            Thread.Sleep(2000);
            input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
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
        static void left(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_A, millisecondsPressed);
        }
        static void left(VirtualKeyCode k)
        {
            left(defaultPressedDuration);
        }
        static void right(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_D, millisecondsPressed);
        }
        static void right(VirtualKeyCode k)
        {
            right(defaultPressedDuration);
        }
        static void up(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_W, millisecondsPressed);
        }
        static void up(VirtualKeyCode k)
        {
            up(defaultPressedDuration);
        }
        static void down(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_S, millisecondsPressed);
        }
        static void down(VirtualKeyCode k)
        {
            down(defaultPressedDuration);
        }
    }
}
