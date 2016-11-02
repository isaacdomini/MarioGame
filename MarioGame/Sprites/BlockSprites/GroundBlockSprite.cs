using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class GroundBlockSprite : BlockSprite
    {
        public enum Frames
        { 
            GroundBlock = 0
        }
        public GroundBlockSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "groundblock";
            NumberOfFramesPerRow = 1;
            //Each state has a frameSet
            FrameSets = new Dictionary<int, Collection<int>> {
                { BlockActionStateEnum.Standard.GetHashCode(), new Collection<int> { Frames.GroundBlock.GetHashCode() } }
            };
            FrameSet = FrameSets[BlockActionStateEnum.Standard.GetHashCode()];
        }
    }
}
