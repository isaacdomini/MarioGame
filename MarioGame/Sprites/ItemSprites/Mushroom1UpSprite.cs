using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame.Sprites
{
    public class Mushroom1UpSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public Mushroom1UpSprite(ContentManager content) : base(content)
        {
            _assetName = "mushroom1Up.png";
        }
    }
}

