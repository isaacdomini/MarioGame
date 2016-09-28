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
    class StepBlock : AnimatedSprite
    {

        public enum Frames
        {
            Step = 0,
        }
        public StepBlock(ContentManager content) : base(content)
        {
            _assetName = "stepblock.png";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Step.GetHashCode() } },
            };
        }
    }
}
