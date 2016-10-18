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
        BlockState usedState;
        BlockState groundState;
        BlockState stepState;
        BlockState brickState;
        BlockState questionState;

        
        internal BlockState UsedState
        {
            get { return usedState; }
        }
        internal BlockState GroundState
        {
            get { return groundState; }
        }
        internal BlockState StepState
        {
            get { return stepState; }
        }
        internal BlockState BrickState
        {
            get { return brickState; }
        }
        internal BlockState QuestionState
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
