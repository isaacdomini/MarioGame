using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class KoopaTroopaSprite : AnimatedSprite
    {
      public KoopaTroopaSprite (ContentManager content) : base(content)
        {
            _assetName = "EnemySpriteSheet2";
        }
}
}