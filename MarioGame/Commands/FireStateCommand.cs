using MarioGame.Core;
using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    internal class FireStateCommand : ScriptCommand
    {
        public FireStateCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            if (Game1.playAsMario == true)
                Script.MakeMarioFire();
        }
    }
}
