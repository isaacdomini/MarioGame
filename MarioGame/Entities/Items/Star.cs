using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class Star : Item
    {
        public Star(Vector2 position, ContentManager content) : base(position, content)
        {
            int _height = 40;
            int _width = 20;
            IsCollidable = true;
            _velocity = MovingVelocity;
        }

        public override void Update(Viewport viewport, GameTime gameTime)
        {
            if (Sprite.Visible == false)
            {
                BoundingBox.X = (int)_position.X;
                BoundingBox.Y = (int)_position.Y;

            }
            base.Update(viewport, gameTime);
        }
    }
}
