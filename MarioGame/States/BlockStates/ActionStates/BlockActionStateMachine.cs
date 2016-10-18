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
        BlockActionState usedState;
        BlockActionState groundState;
        BlockActionState stepState;
        BlockActionState brickState;
        BlockActionState questionState;

        
        internal BlockActionState UsedState
        {
            get { return usedState; }
        }
        internal BlockActionState GroundState
        {
            get { return groundState; }
        }
        internal BlockActionState StepState
        {
            get { return stepState; }
        }
        internal BlockActionState BrickState
        {
            get { return brickState; }
        }
        internal BlockActionState QuestionState
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
