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
    public class PipeSectionSprite : AnimatedSprite
    {
        public enum Frames
        {
            PipeSection = 0
        }
        public PipeSectionSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "pipesection";
            NumberOfFramesPerRow = 1;
            //Each state has a frameSet
            FrameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.PipeSection.GetHashCode() } }
            };
            FrameSet = FrameSets[0];
        }
    }
}
