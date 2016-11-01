using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Cloud2Sprite : BackgroundItemSprite
    {
        public Cloud2Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Cloud2.GetHashCode()];
            FrameSetPosition = Frames.Cloud2.GetHashCode();
        }
    }
}
