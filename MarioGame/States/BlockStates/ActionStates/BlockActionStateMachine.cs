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
        Block _block;
        UsedBlockState usedState;
        GroundBlockState groundState;
        StepBlockState stepState;
        BrickBlockState brickState;
        QuestionBlockState questionState;

        
        internal UsedBlockState UsedState
        {
            get { return usedState; }
        }
        internal GroundBlockState GroundState
        {
            get { return groundState; }
        }
        internal StepBlockState StepState
        {
            get { return stepState; }
        }
        internal BrickBlockState BrickState
        {
            get { return brickState; }
        }
        internal QuestionBlockState QuestionState
        {
            get { return questionState; }
        }

        public BlockActionStateMachine(Block block)
        {
            _block = block;
            usedState = new UsedBlockState(_block, this);
            brickState = new BrickBlockState(_block, this);
            groundState = new GroundBlockState(_block, this);
            stepState = new StepBlockState(_block, this);
            questionState = new QuestionBlockState(_block, this);
        }
    }
}
