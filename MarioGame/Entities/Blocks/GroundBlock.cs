using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace MarioGame.Entities
{
    public class GroundBlock : Block
    {
        public GroundBlock(Vector2 position, ContentManager content) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }
    }
}
