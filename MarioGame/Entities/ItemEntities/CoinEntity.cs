
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class CoinEntity : Entity
    {
        public CoinEntity(Vector2 position, CoinsSprite sprite) : base(position, sprite)
        {
        }
        public override void Update() { }
    }
}
