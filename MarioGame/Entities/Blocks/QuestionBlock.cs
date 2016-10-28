using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.Blocks
{
    class QuestionBlock : Block, IBumpable
    {
        public QuestionBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
