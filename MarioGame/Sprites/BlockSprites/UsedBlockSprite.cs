using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.BlockSprites
{
    public class UsedBlockSprite : AnimatedSprite
    {

        public enum Frames
        {
            Used = 0,
        }
        public UsedBlockSprite(ContentManager content) : base(content)
        {
            _assetName = "usedblock";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Used.GetHashCode() } },
            };
        }
    }
}
