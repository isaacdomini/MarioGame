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
    public class BrickBlockSprite : BlockSprite
    {
        public enum Frames
        {
            BrickBlock = 0,
            UsedBlock = 1
        }
        protected override void DefineFrameSets()
        {
            base.DefineFrameSets();
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;
            //Each state has a frameSet
            FrameSets = new Dictionary<int, Collection<int>> {
                { BlockActionStateEnum.Standard.GetHashCode(), new Collection<int> { Frames.BrickBlock.GetHashCode() } },
                { BlockActionStateEnum.Bumping.GetHashCode(), new Collection<int> { Frames.BrickBlock.GetHashCode() } },
                { BlockActionStateEnum.Used.GetHashCode(), new Collection<int> { Frames.UsedBlock.GetHashCode() } }
            };
        }
        public BrickBlockSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "brickblock";
        }
    }
}
