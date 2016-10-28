using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.Blocks
{
    class StepBlock : Block
    {
        public StepBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
