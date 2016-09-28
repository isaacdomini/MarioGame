using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.ItemSprites
{
    public class BrickBlockSprite : AnimatedSprite
    {

        public enum Frames
        {
            Brick = 0,
        }
        public BrickBlockSprite(ContentManager content) : base(content)
        {
            _assetName = "brick1.png";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Brick.GetHashCode() } },
            };
        }
    }
}
