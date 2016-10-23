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
            isCollidable = true;
        }
    }
}
