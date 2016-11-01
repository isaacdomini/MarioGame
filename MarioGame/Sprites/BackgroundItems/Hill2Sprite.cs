using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class Hill2Sprite : BackgroundItemSprite
    {
        public Hill2Sprite(ContentManager content, Entity entity) : base(content, entity)
        {
            FrameSet = FrameSets[Frames.Hill2.GetHashCode()];
            FrameSetPosition = Frames.Hill2.GetHashCode();
        }
    }
}
