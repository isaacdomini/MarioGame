using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class DeadStateCommand :ScriptCommand
    {
        public DeadStateCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            Script.MakeMarioDead();
        }
    }
}
