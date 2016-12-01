using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using MarioGame.Entities;

namespace MarioGame.LevelLearner
{
    public class LevelLearner
    {
        private static LevelLearner _levelLearner;
        private Mario _mario;

        public LevelLearner(Mario mario)
        {
            this._mario = mario;
        }
        public static LevelLearner GetInstance(Mario _mario)
        {
            return _levelLearner ?? (_levelLearner = new LevelLearner(_mario));
        }

        public void Start()
        {

        }
    }
}
