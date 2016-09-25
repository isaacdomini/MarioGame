using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class StaticStillSprite : Sprite
    {
        public StaticStillSprite(Vector2 spritePos)
        {
            Visible = false;
            _position = spritePos;
        }
    }
}