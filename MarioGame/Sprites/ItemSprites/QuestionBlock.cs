using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.ItemSprites
{
    class QuestionBlock : AnimatedSprite
    {
        public QuestionBlock(ContentManager content) : base(content)
        {
            _numberOfFramesPerRow = 3;
        }
    }
}
