using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace MarioGame.HardcodedAI
{

    public class KeyPresser
    {
        public Queue<KeyPress> keyPresses;
        static InputSimulator input = new InputSimulator();
        private static bool _pressing;
        private float startTime;
        private float elapsedTime;
        private KeyPress currKeyPress;
        private List<VirtualKeyCode> currKeyCodes => GetKeyCodes(currKeyPress);
        public static IDictionary<string, VirtualKeyCode> keyMap = new Dictionary<string, VirtualKeyCode>()
        {
            { "left", VirtualKeyCode.VK_A},
            { "right", VirtualKeyCode.VK_D},
            { "up", VirtualKeyCode.VK_W},
            { "down", VirtualKeyCode.VK_S}
        };
        public KeyPresser(Queue<KeyPress> commands)
        {
            keyPresses = commands;
        }

        public void UpdateKeyPress(GameTime gameTime)
        {
            if (!_pressing)
            {

                _pressing = true;
                startTime = gameTime.TotalGameTime.Milliseconds;
                Console.WriteLine("Getting new key press.");

                if (keyPresses.Count > 0)
                {
                    currKeyPress = keyPresses.Dequeue();
                    press();
                }
                else
                {
                    Console.WriteLine("No more key presses.");
                }

            }
            else
            {
                elapsedTime = gameTime.TotalGameTime.Milliseconds - startTime;
                if (currKeyPress.duration < elapsedTime)
                {
                    Console.WriteLine("Elapsed time: " + elapsedTime);
                    keyUp();
                    _pressing = false;
                }
            }

        }



        private List<VirtualKeyCode> GetKeyCodes(KeyPress keyPress)
        {
            List<VirtualKeyCode> kCodes = new List<VirtualKeyCode>();
            foreach (var key in keyPress.keys)
            {
                VirtualKeyCode kCode = keyMap[key];
                kCodes.Add(kCode);
            }
            return kCodes;
        }

        private void press()
        {
            Console.Write("Pressing keys: ");
            foreach (var keyCode in currKeyCodes)
            {
                Console.Write(keyCode.ToString());
            }
            Console.WriteLine();
            //currKeyCodes.ForEach(k => input.Keyboard.KeyDown(k));
  
        }
        private void keyUp()
        {
            Console.Write("Lifting keys: ");
            foreach (var keyCode in currKeyCodes)
            {
                Console.Write(keyCode.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Key press duration: " + currKeyPress.duration);
            Console.WriteLine();
            Console.WriteLine();
            //currKeyCodes.ForEach(k => input.Keyboard.KeyUp(k));
        }
    }

}
