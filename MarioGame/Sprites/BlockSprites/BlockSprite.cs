using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using System.Collections.Generic;
using System.Collections;
using MarioGame.States;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class BlockSprite : AnimatedSprite
    {
        public enum Frames
        {
            BrickBlock = 0,
            UsedBlock = 1,
            //GroundBlock = 2
            GroundBlock = 3,
            StepBlock = 4,
            SilverBlock = 5,
            QuestionBlock1 =6,
            QuestionBlock2 = 7,
            QuestionBlock3 = 8,
        }
        public enum Rows
        {
            Visible = 0,
            Row = 1
        }

        public BlockSprite(ContentManager content) : base(content)
        {
            _numberOfFramesPerRow = 15;
            //Each state has a frameSet
            _frameSets = new Dictionary<int, List<int>> {
                { BlockStateEnum.BrickBlock.GetHashCode(), new List<int> { Frames.BrickBlock.GetHashCode() } },
                { BlockStateEnum.UsedBlock.GetHashCode(), new List<int> { Frames.UsedBlock.GetHashCode() } },
                { BlockStateEnum.GroundBlock.GetHashCode(), new List<int> { Frames.GroundBlock.GetHashCode() } },
                { BlockStateEnum.StepBlock.GetHashCode(), new List<int> { Frames.StepBlock.GetHashCode() } },
                { BlockStateEnum.SilverBlock.GetHashCode(), new List<int> { Frames.SilverBlock.GetHashCode() } },
                { BlockStateEnum.QuestionBlock.GetHashCode(), new List<int> {Frames.QuestionBlock1.GetHashCode(), Frames.QuestionBlock2.GetHashCode(), Frames.QuestionBlock3.GetHashCode() } },
            };
        }
        public void changeActionState(BlockActionState actionState)
        {
            _frameSet = _frameSets[actionState.actionState.GetHashCode()];
        }
        public void changePowerUp(MarioPowerUpState marioPowerUpState)
        {
            base.changePowerUp(marioPowerUpState);
            _rowSet = _rowSets[marioPowerUpState.powerUpState.GetHashCode()];
        }

    }
}