using System;
using MarioGame.Entities.Items;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class Mushroom1Up : PowerUp
    {
        public Mushroom1Up(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            _velocity = MovingVelocity;
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            if (Sprite is BlockSprite)
            {
                if (!((BlockSprite)Sprite).isVisible)
                {
                    BoundingBox.X = (int)PositionX;
                    BoundingBox.Y = (int)PositionY;
                }

            }
            base.Update(viewport, elapsedMilliseconds);
        }
    }
}
