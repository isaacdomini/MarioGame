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
    public class GroundBlockSprite : AnimatedSprite
    {

        public enum Frames
        {
            Ground = 0,
        }
        public GroundBlockSprite(ContentManager content) : base(content)
        {
            _assetName = "groundblock.png";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Ground.GetHashCode() } },
            };
        }
    }
}
