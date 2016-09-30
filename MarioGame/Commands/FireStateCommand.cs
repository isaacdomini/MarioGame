using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class FireStateCommand : ScriptCommand
    {
        public FireStateCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            Script.MakeMarioFire();
        }
    }
}
