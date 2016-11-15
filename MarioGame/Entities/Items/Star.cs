using System;
using MarioGame.Entities.Items;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class Star : PowerUp
    {
        public Star(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            _velocity = MovingVelocity;
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            if (((StarSprite)Sprite).isVisible == false)
            {
                BoundingBox.X = (int)_position.X;
                BoundingBox.Y = (int)_position.Y;

            }
            base.Update(viewport, elapsedMilliseconds);
        }
    }
}
