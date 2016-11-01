using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    class PipeTop : Block
    {
        public PipeTop(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
