using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class StepBlockState : BlockActionState
    {
        public StepBlockState(Block block, BlockActionStateMachine stateMachine) : base (block, stateMachine)
        {
             BState = BlockActionStateEnum.StepBlock;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Block.ChangeBlockActionState(StateMachine.StepState);
        }
    }
}
