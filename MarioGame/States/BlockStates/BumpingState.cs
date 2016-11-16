using MarioGame.Entities;
using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;

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

            Entities.Entity.Script.Announce(EventTypes.Bump);
        }
        public override void EndState()
        {
            base.EndState();
            PrevState = this;
        }
        public override void ChangeToUsed()
        {
            EndState();
            StateMachine.UsedState.Begin(this);
        }
        public override void ChangeToStandard()
        {
            EndState();
            StateMachine.StandardState.Begin(this);
        }
    }
}
