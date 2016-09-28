using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using System.Collections.Generic;
using System.Collections;
using MarioGame.States.BlockStates;

namespace MarioGame.Sprites.BlockSprite
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

        //power up states - standard(small), super(big), fire ,start (invincible), Dead

        public BlockSprite(ContentManager content) : base(content)
        {
            _numberOfFramesPerRow = 15;
            //Each state has a frameSet
            _frameSets = new Dictionary<int, List<int>> {
                { BlockStates.StandardBlock.GetHashCode(), new List<int> { Frames.StandardBlock.GetHashCode() } },
                { BlockStates.GroundBlock.GetHashCode(), new List<int> { Frames.GroundBlock.GetHashCode() } },
                { BlockStates.StepBlock.GetHashCode(), new List<int> { Frames.StepBlock.GetHashCode() } },
                { BlockStates.BreakingBlock.GetHashCode(), new List<int> {Frames.BreakingBlock.GetHashCode() } },
                { BlockStates.QuestionBlock.GetHashCode(), new List<int> {Frames.QuestionBlock1.GetHashCode(), Frames.QuestionBlock2.GetHashCode(), Frames.QuestionBlock3.GetHashCode() } },
                { BlockStates.HiddenBlock.GetHashCode(), new List<int> {Frames.HiddenBlock.GetHashCode() } },
                { BlockStates.UsedBlock.GetHashCode(), new List<int> { Frames.UsedBlock.GetHashCode() } },

            };
        }

    }
}