
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.ItemEntities
{
    public class MushroomSuperEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public MushroomSuper iSprite;
        public Viewport viewport;
        IEntity mushroom;
        ContentManager content;
        public MushroomSuperEntity(Vector2 position) : base(position)
        {
            iSprite = new MushroomSuper(mushroom, content, viewport);
        }
        public override void Update() { }
    }
}
