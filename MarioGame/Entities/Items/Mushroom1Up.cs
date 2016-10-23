using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Mushroom1Up : Item
    {
        public Mushroom1Up(Vector2 position, ContentManager content) : base(position, content)
        {
            int _height = 40;
            int _width = 20;
            isCollidable = true;
        }
    }
}
