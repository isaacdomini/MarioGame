using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates
{
    public class StepBlockState : BlockState
    {
        public StepBlockState(StepBlock block, BlockStateMachine stateMachine) : base (block, stateMachine)
        {
            bState = BlockStateEnum.StepBlock;
        }
    }
}
