using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class Mushroom1Up : Item
    {
        public Mushroom1Up(Vector2 position, ContentManager content) : base(position, content)
        {
            IsCollidable = true;
            _velocity = MovingVelocity;
        }

        public override void Update(Viewport viewport, GameTime gameTime)
        {
            if (Sprite is BlockSprite)
            {
                if (!((BlockSprite)Sprite).isVisible)
                {
                    BoundingBox.X = (int)_position.X;
                    BoundingBox.Y = (int)_position.Y;
                }

            }
            base.Update(viewport, gameTime);
        }
    }
}
