using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.BlockSprites
{
    class BrokenBrickSprite : AnimatedSprite
    {
        public enum Frames
        {
            Brick1 = 0,
        }
        public BrokenBrickSprite(ContentManager content) : base(content)
        {
            _assetName = "BrokenBrick";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Brick1.GetHashCode(), Frames.Brick1.GetHashCode(), Frames.Brick1.GetHashCode(), Frames.Brick1.GetHashCode() } },
            };
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}
