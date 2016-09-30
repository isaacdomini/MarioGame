using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using System.Collections.Generic;
using System.Collections;
using MarioGame.States.BlockStates;

namespace MarioGame.Sprites.BlockSprites
{
    public class BlockSprite : AnimatedSprite
    {

        public enum Frames
        {
            StandardBlock = 0,
            StepBlock = 4,
            GroundBlock = 0,
            BumpBlock = 0,
            BreakingBlock = 3,
            QuestionBlock1 =6,
            QuestionBlock2 = 7,
            QuestionBlock3 = 8,
            HiddenBlock = 0,
            UsedBlock = 1
        }

        public BlockSprite(ContentManager content) : base(content)
        {
            _numberOfFramesPerRow = 15;
            //Each state has a frameSet
            _frameSets = new Dictionary<int, List<int>> {
                { BlockStateEnum.StandardBlock.GetHashCode(), new List<int> { Frames.StandardBlock.GetHashCode() } },
                { BlockStateEnum.GroundBlock.GetHashCode(), new List<int> { Frames.GroundBlock.GetHashCode() } },
                { BlockStateEnum.StepBlock.GetHashCode(), new List<int> { Frames.StepBlock.GetHashCode() } },
                { BlockStateEnum.BreakingBlock.GetHashCode(), new List<int> {Frames.BreakingBlock.GetHashCode() } },
                { BlockStateEnum.QuestionBlock.GetHashCode(), new List<int> {Frames.QuestionBlock1.GetHashCode(), Frames.QuestionBlock2.GetHashCode(), Frames.QuestionBlock3.GetHashCode() } },
                { BlockStateEnum.HiddenBlock.GetHashCode(), new List<int> {Frames.HiddenBlock.GetHashCode() } },
                { BlockStateEnum.UsedBlock.GetHashCode(), new List<int> { Frames.UsedBlock.GetHashCode() } },

            };
        }

    }
}