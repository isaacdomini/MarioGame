using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class MushroomSuper : Item
    {
        public MushroomSuper(Vector2 position, ContentManager content) : base(position, content)
        {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height / 2);
            boxColor = Color.Green;
            isCollidable = true;
            _velocity = idleVelocity;
        }

        public override void Update()
        {
            if (_sprite.Visible == false)
            {
                _velocity = -1*movingVelocity;
                boundingBox.X = (int)_position.X;
                boundingBox.Y = (int)_position.Y;

            }
            base.Update();
        }
    }
}
