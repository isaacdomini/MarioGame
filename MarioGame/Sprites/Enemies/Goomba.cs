using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class Goomba : AnimatedSprite
    {
        public Goomba(IEntity entity) : base(entity)
        {
            _assetName = "putTheSpriteSheetNameHereErin";
        }
    }
}