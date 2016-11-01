using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame.Sprites
{
    public class Mushroom1UpSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public Mushroom1UpSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "mushroom1Up";
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

