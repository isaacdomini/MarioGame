using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class BlockActionStateMachine
    {
        internal UsedBlockState UsedState { get; }

        internal GroundBlockState GroundState { get; }

        internal StepBlockState StepState { get; }

        internal BrickBlockState BrickState { get; }

        internal QuestionBlockState QuestionState { get; }

        public BlockActionStateMachine(Block block)
        {
            var block1 = block;
            UsedState = new UsedBlockState(block1, this);
            BrickState = new BrickBlockState(block1, this);
            GroundState = new GroundBlockState(block1, this);
            StepState = new StepBlockState(block1, this);
            QuestionState = new QuestionBlockState(block1, this);
        }
    }
}
