
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class ItemEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public Coins iSprite;
        public Viewport viewport;
        IEntity coins;
        ContentManager content;
        public ItemEntity(Vector2 position) : base(position)
        {
            iSprite = new Coins(coins, content, viewport);
        }
        public override void Update() { }
    }
}
