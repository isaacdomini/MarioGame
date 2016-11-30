using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WindowsInput.Native;
using MarioGame.Theming;

namespace MarioGame.HardcodedAI
{
    internal static class Interpreter
    {
        public static Queue<KeyPress> AILoader(string AICommandFile)
        {
            var json = File.ReadAllText(AICommandFile);
            var commandLists = JsonConvert.DeserializeObject<Commands>(json);

            Queue<KeyPress> keyPresses = commandLists.keyPresses;

            return keyPresses;

        }
    }
    public class KeyPress
    {
        public List<string> keys { get; set; }
        public int duration { get; set; }
    }

    public class Commands
    {
        public Queue<KeyPress> keyPresses { get; set; }
    }
}
