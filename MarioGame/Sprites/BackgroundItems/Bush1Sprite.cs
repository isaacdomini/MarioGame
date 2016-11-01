using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Bush1Sprite : BackgroundItemSprite
    {
        public Bush1Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Bush1.GetHashCode()];
            FrameSetPosition = Frames.Bush1.GetHashCode();
        }
    }
}
