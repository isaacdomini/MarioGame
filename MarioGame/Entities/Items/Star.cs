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
            isCollidable = true;
        }

        public override void Update(Viewport viewport)
        {
            if (_sprite.Visible == false)
            {
                _velocity = movingVelocity;
                boundingBox.X = (int)_position.X;
                boundingBox.Y = (int)_position.Y;

            }
            base.Update(viewport);
        }
    }
}
