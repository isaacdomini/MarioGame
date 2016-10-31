using MarioGame.States.BlockStates.ActionStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates
{
    public class BlockActionStateMachine
    {
        internal UsedBlockState UsedState { get; }

        internal StandardState StandardState { get; }

        internal BumpingState BumpingState { get; }

        internal BreakingState BreakingState { get; }
        
        public BlockActionStateMachine(Entities.Block block)
        {
            var block1 = block;
            UsedState = new UsedBlockState(block1, this);
            StandardState = new StandardState(block1, this);
            BumpingState = new BumpingState(block1, this);
            BreakingState = new BreakingState(block1, this);
        }
    }
}
