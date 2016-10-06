
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
        public static Rectangle boundingBox;
        public static Color boxColor;

        public MushroomSuperEntity(Vector2 position, MushroomSuperSprite sprite) : base(position, sprite)
        {
            iSprite = sprite;
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height / 2);
            boxColor = Color.Green;
        }
        public override void Update() { }
    }
}
