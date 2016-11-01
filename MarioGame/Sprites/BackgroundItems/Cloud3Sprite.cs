using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Cloud3Sprite : BackgroundItemSprite
    {
        public Cloud3Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Cloud3.GetHashCode()];
            FrameSetPosition = Frames.Cloud3.GetHashCode();
        }
    }
}
