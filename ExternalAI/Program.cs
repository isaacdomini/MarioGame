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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InputSimulator input = new InputSimulator();
            Thread.Sleep(3000);
            input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            Thread.Sleep(2000);
            input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
        }
    }
}
