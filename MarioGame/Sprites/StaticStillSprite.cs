using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class StillSprite : Sprite
    {
        public StillSprite(IEntity entity) : base(entity)
        {
        }
    }
}