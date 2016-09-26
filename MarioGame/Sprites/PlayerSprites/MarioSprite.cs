using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.Sprites.PlayerSprites
{
    public class MarioSprite : AnimatedSprite
    {
        
        public MarioSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _numberOfFrames = 15;
        }

    }
}
