using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class GroundBlockState : BlockActionState
    {
        public GroundBlockState(Block block, BlockActionStateMachine stateMachine): base(block, stateMachine)
        {
            bState = BlockActionStateEnum.GroundBlock;
        }
        public override void Begin(BlockActionState prevState)
        {
            block.ChangeBlockActionState(stateMachine.GroundState);
        }
    }
}
