using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame.Sprites
{
    public class MushroomSuperSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public MushroomSuperSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            _assetName = "mushroomSuper";
        }
    }
}

