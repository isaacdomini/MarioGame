using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class DrawBoundingBoxes : ScriptCommand
    {
        public DrawBoundingBoxes(Script script) : base(script)
        {
        }

        public override void Execute()
        {
            Script.DrawBoundingBoxes();
        }
    }
}
