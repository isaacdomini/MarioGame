using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarioGame.Theming;
using MarioGame.Core;
using MarioGame.LevelLearner;

namespace MarioGame.Commands
{
    internal class LevelLearnerCommand : ScriptCommand 
    {
        public LevelLearnerCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            new Thread(delegate ()
            {
                LevelLearner.LevelLearner.GetInstance(Script.Mario).Start();
            }).Start();
            
        }
    }
}
