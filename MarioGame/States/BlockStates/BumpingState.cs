using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates.ActionStates
{
    public class BumpingState : BlockActionState
    {
        public BumpingState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            BState = BlockActionStateEnum.Bumping;

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.BumpingState);
        }
        public override void End()
        {
            base.End();
            PrevState = this;
        }
        public override void ChangeToUsed()
        {
            this.End();
            StateMachine.UsedState.Begin(this);
        }
        public override void ChangeToStandard()
        {
            this.End();
            StateMachine.StandardState.Begin(this);
        }
    }
}
