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

        public BlockSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _numberOfFrames = 15;
            //Each state has a frameSet
            _frameSets = new Dictionary<BlockStates, List<Frames>> {
                { BlockStates.StandardBlock, new List<Frames> { Frames.StandardBlock } },
                { BlockStates.GroundBlock, new List<Frames> { Frames.GroundBlock } },
                { BlockStates.StepBlock, new List<Frames> { Frames.StepBlock } },
                { BlockStates.BreakingBlock, new List<Frames> {Frames.BreakingBlock} },
                { BlockStates.QuestionBlock, new List<Frames> {Frames.QuestionBlock1, Frames.QuestionBlock2, Frames.QuestionBlock3 } },
                { BlockStates.HiddenBlock, new List<Frames> {Frames.HiddenBlock} },
                { BlockStates.UsedBlock, new List<Frames> { Frames.UsedBlock } },

            };
        }

    }
}