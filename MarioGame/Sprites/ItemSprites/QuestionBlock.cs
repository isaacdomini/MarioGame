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
        public QuestionBlock(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _numberOfFrames = 3;
        }
    }
}