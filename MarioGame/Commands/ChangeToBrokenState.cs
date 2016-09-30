﻿using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class ChangeToBrokenState : ScriptCommand
    {
        public ChangeToBrokenState(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            Script.BreakBrick();
        }
    }
}
