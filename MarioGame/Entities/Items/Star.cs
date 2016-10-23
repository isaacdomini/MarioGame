using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Star : Item
    {
        public Star(Vector2 position, ContentManager content) : base(position, content)
        {
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)Position.X, (int)Position.Y, _width*3/4, _height / 2);
            boxColor = Color.Green;
            isCollidable = true;
        }
    }
}
