using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Hill1Sprite : BackgroundItemSprite
    {
        public Hill1Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Hill1.GetHashCode()];
            FrameSetPosition = Frames.Hill1.GetHashCode();
        }
    }
}
