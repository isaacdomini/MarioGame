using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Theming;
using MarioGame.Core;

namespace MarioGame.Commands
{
    internal class DashOrThrowFireballCommand : ScriptCommand
    {
        public DashOrThrowFireballCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            if (Game1.playAsMario == true)
                Script.MakeMarioDashOrThrowFireball();
        }
    }
}
