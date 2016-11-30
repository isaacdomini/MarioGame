using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WindowsInput.Native;


namespace ExternalAI
{
    internal static class Interpreter
    {
        public static void AILoader(string AICommandFile)
        {
            var json = File.ReadAllText(AICommandFile);
            var commandLists = JsonConvert.DeserializeObject<Commands>(json);

            List<KeyPress> keyPresses = commandLists.keyPresses;
            

            foreach (var keyPress in keyPresses)
            {
                PressKey(keyPress);
            }

        }
        internal static void PressKey(KeyPress keyPress)
        {
            List<VirtualKeyCode> kCodes = new List<VirtualKeyCode>();
            foreach (var key in keyPress.keys)
            {
                VirtualKeyCode kCode = Program.keyMap[key];
                kCodes.Add(kCode);
            }
            Program.press(kCodes, keyPress.duration);
        }
    }
    public class KeyPress
    {
        public List<string> keys { get; set; }
        public int duration { get; set; }
    }

    public class Commands
    {
        public List<KeyPress> keyPresses { get; set; }
    }
}
