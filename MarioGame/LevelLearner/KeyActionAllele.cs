using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace MarioGame.LevelLearner
{
    internal class KeyActionAllele
    {
        public List<VirtualKeyCode> Keys;
        private int _duration;
        public float Fitess;
        private InputSimulator _input;

        public KeyActionAllele(List<VirtualKeyCode> keys, int duration, InputSimulator input)
        {
            Keys = keys;
            _duration = duration;
            _input = input;
        }
        
        public void Act()
        {
            Keys.ForEach(key => _input.Keyboard.KeyDown(key));
            Thread.Sleep(_duration);
            Keys.ForEach(key => _input.Keyboard.KeyUp(key));
        }
    }
}
