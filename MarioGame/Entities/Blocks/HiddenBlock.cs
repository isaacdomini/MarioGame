using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace MarioGame.Entities
{
    public class HiddenBlock : BumpableContainerBlock
    {
        public HiddenBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
