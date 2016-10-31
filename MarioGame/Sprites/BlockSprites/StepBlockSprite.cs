using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class StepBlockSprite : BlockSprite
    {
        public enum Frames
        {
            StepBlock = 0
        }
        public StepBlockSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "stepblock";
            NumberOfFramesPerRow = 1;
            //Each state has a frameSet
            FrameSets = new Dictionary<int, List<int>> {
                { BlockActionStateEnum.Standard.GetHashCode(), new List<int> { Frames.StepBlock.GetHashCode() } }
            };
            FrameSet = FrameSets[BlockActionStateEnum.Standard.GetHashCode()];
        }
    }
}
