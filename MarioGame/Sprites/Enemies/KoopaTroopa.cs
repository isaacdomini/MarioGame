using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class KoopaTroopa : Sprite
    {
      public KoopaTroopa (IEntity entity) : base(entity)
        {
            _assetName = "EnemySpriteSheet2";
        }
}
}