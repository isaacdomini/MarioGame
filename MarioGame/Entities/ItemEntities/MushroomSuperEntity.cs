
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class MushroomSuperEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public MushroomSuperSprite iSprite;
        ContentManager content;
        public MushroomSuperEntity(Vector2 position, MushroomSuperSprite sprite) : base(position, sprite)
        {
            iSprite = sprite;
        }
        public override void Update() { }
    }
}
