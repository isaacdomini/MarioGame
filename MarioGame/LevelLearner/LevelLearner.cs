using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using MarioGame.Entities;
using MarioGame.States;

namespace MarioGame.LevelLearner
{
    public class LevelLearner
    {
        private static LevelLearner _levelLearner;
        private readonly Mario _mario;
        private float _previousPosition;
        private static readonly VirtualKeyCode[] _keys = {VirtualKeyCode.VK_W, VirtualKeyCode.VK_S, VirtualKeyCode.VK_A, VirtualKeyCode.VK_D};

        public LevelLearner(Mario mario)
        {
            _mario = mario;
            _previousPosition = _mario.Position.X-100;
        }
        public static LevelLearner GetInstance(Mario _mario)
        {
            return _levelLearner ?? (_levelLearner = new LevelLearner(_mario));
        }

        public void Start()
        {

            int keyIndex1 = new Random().Next(0, 4);
            int keyIndex2 = new Random().Next(0, 4);
            int simulKeys = new Random().Next(0, 2);
            var input = new InputSimulator();
            input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            if (_mario.MarioPowerUpState is DeadState)
            {
                return;
            }
            while (!(_mario.MarioPowerUpState is DeadState))
            {
                Console.WriteLine("InLoop");
                if (_previousPosition >= _mario.Position.X)
                {
                    input.Keyboard.KeyUp(_keys[keyIndex1]);
                    if (simulKeys == 1)
                    {
                        input.Keyboard.KeyUp(_keys[keyIndex2]);
                    }
                    keyIndex1 = new Random().Next(0,4);
                    keyIndex2 = new Random().Next(0,4);
                    simulKeys = new Random().Next(0,2);
                    Console.WriteLine("NoImprovement"+ _previousPosition +" Current:" + _mario.Position.X);
                    input.Keyboard.KeyDown(_keys[keyIndex1]);
                    if (simulKeys == 1)
                    {
                        input.Keyboard.KeyDown(_keys[keyIndex2]);
                    }
                    Thread.Sleep(1000);

                }
                else
                {
                    Console.WriteLine("Imporvement");
                    Thread.Sleep(1000);
                }
                _previousPosition = _mario.Position.X;
            }
        }
    }
}
