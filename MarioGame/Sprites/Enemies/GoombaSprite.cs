using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class GoombaSprite : AnimatedSprite
    {
        public GoombaSprite(ContentManager content) : base(content)
        {
            _assetName = "EnemySpriteSheet2";
        }
    }
}