using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Cloud1Sprite : BackgroundItemSprite
    {
        public Cloud1Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Cloud1.GetHashCode()];
            FrameSetPosition = Frames.Cloud1.GetHashCode();
        }
    }
}
