using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame.Sprites
{
    public class MushroomSuperSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public MushroomSuperSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "mushroomSuper";
        }
        public override void Draw(SpriteBatch batch)
        {
            if (isVisible)
            {
                base.Draw(batch);
            }
        }
    }
}

