using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class BlockStateMachine
    {
        Block _block;
        BlockState hiddenState;
        BlockState usedState;
        BlockState groundState;
        BlockState stepState;
        BlockState brickState;

        
        internal BlockState HiddenState
        {
            get { return hiddenState; }
        }
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

        public BlockStateMachine(Block block)
        {
            _block = block;
            hiddenState = new HiddenBlockState(_block, this);
            usedState = new UsedBlockState(_block, this);
            brickState = new BrickBlockState((BrickBlock)_block, this);
            groundState = new GroundBlockState((GroundBlock)_block, this);
            stepState = new StepBlockState((StepBlock)_block, this);
        }
    }
}
