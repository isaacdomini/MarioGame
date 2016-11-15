using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Theming;

namespace MarioGame.Commands
{
    class MuteCommand : ScriptCommand
    {
        public MuteCommand(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            Script.MuteSounds();
        }
    }
}
