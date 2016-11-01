using System;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class MushroomSuper : Item
    {
        public MushroomSuper(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            _velocity = -1 * MovingVelocity;
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            if (((MushroomSuperSprite)Sprite).isVisible == false)
            {
                BoundingBox.X = (int)_position.X;
                BoundingBox.Y = (int)_position.Y;

            }
            base.Update(viewport, elapsedMilliseconds);
        }
    }
}
