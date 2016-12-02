using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private static readonly VirtualKeyCode[] Keys = {VirtualKeyCode.VK_W, VirtualKeyCode.VK_S, VirtualKeyCode.VK_A, VirtualKeyCode.VK_D};
        private List<KeyActionAllele> _actionAlleles;
        public LevelLearner(Mario mario)
        {
            _mario = mario;
            _previousPosition = _mario.Position.X-100;
            _actionAlleles = new List<KeyActionAllele>();
        }
        public static LevelLearner GetInstance(Mario mario)
        {
            return _levelLearner ?? (_levelLearner = new LevelLearner(mario));
        }

        private float getBestFitness()
        {
            return _actionAlleles.Aggregate<KeyActionAllele, float>(0, (current, action) => (action.Fitess > current) ? action.Fitess : current);
        }

        public void Start()
        {
            float maxFitness = getBestFitness();
            if (_actionAlleles.Count > 0)
            {
                int currentActionIndex = 0;
                KeyActionAllele currentActionAllele = _actionAlleles[currentActionIndex];
                while (currentActionAllele.Fitess<maxFitness)
                {
                    currentActionAllele.Act();
                    currentActionAllele = _actionAlleles[++currentActionIndex];
                }
            }
            if (_mario.MarioPowerUpState is DeadState)
            {
                return;
            }
            var input = new InputSimulator();
            int keyIndex1 = new Random().Next(0, Keys.Length);
            int keyIndex2 = new Random().Next(0, 4);
            int simulKeys = new Random().Next(0, 2);
            while (!(_mario.MarioPowerUpState is DeadState))
            {   

                Console.WriteLine("InLoop");
                if (_previousPosition >= _mario.Position.X)
                {
                    input.Keyboard.KeyUp(Keys[keyIndex1]);
                    if (simulKeys == 1)
                    {
                        input.Keyboard.KeyUp(Keys[keyIndex2]);
                    }
                    keyIndex1 = new Random().Next(0,4);
                    keyIndex2 = new Random().Next(0,4);
                    simulKeys = new Random().Next(0,2);
                    Console.WriteLine("NoImprovement"+ _previousPosition +" Current:" + _mario.Position.X);
                    input.Keyboard.KeyDown(Keys[keyIndex1]);
                    if (simulKeys == 1)
                    {
                        input.Keyboard.KeyDown(Keys[keyIndex2]);
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
