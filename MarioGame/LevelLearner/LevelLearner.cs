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
        private static readonly VirtualKeyCode[] Keys = {VirtualKeyCode.VK_A, VirtualKeyCode.VK_S, VirtualKeyCode.VK_W, VirtualKeyCode.VK_D};
        private readonly List<KeyActionAllele> _actionAlleles;
        private readonly InputSimulator _input;
        public LevelLearner(Mario mario)
        {
            _mario = mario;
            _previousPosition = _mario.Position.X-100;
            _actionAlleles = new List<KeyActionAllele>();
            _input = new InputSimulator();
        }
        public static LevelLearner GetInstance(Mario mario)
        {
            return _levelLearner ?? (_levelLearner = new LevelLearner(mario));
        }

        private float GetBestFitness()
        {
            return _actionAlleles.Aggregate<KeyActionAllele, float>(0, (current, action) => (action.Fitess > current) ? action.Fitess : current);
        }

        public void Start()
        {
            float maxFitness = GetBestFitness();
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
            //int keyIndex1 = new Random().Next(0, Keys.Length);
            //int keyIndex2 = new Random().Next(0, 4);
            //int simulKeys = new Random().Next(0, 2);
            while (!(_mario.MarioPowerUpState is DeadState))
            {   

                Console.WriteLine("InLoop");
                if (_previousPosition >= _mario.Position.X)
                {
                    List<VirtualKeyCode> tempKeys = new List<VirtualKeyCode>();
                    for (int i = 0; i < new Random().Next(0, 3); i++)
                    {
                        tempKeys.Add(Keys[new Random().Next(0,Keys.Length)]);
                    }
                    KeyActionAllele tempAction = new KeyActionAllele(tempKeys, (new Random().Next(1,5))/2 * 1000, _input);
                    tempAction.Act();
                    tempAction.Fitess = _mario.Position.X;
                    _actionAlleles.Add(tempAction);

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
