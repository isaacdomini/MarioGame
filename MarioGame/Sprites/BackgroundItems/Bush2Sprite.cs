using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Bush2Sprite : BackgroundItemSprite
    {
        public Bush2Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Bush2.GetHashCode()];
            FrameSetPosition = Frames.Bush2.GetHashCode();
        }
    }
}
