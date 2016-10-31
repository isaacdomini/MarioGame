using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    public class BreakingState : BlockActionState
    {
        public BreakingState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            BState = BlockActionStateEnum.Breaking;

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.BreakingState);
        }
        public override void End()
        {
            base.End();
            PrevState = this;
        }
    }
}
