using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates
{
    public class StandardState : BlockActionState
    {
        public StandardState(Block block, BlockActionStateMachine stateMachine) : base(block, stateMachine)
        {
            BState = BlockActionStateEnum.Standard;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.StandardState);
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
        public override void Bump()
        {
            this.End();
            StateMachine.BumpingState.Begin(this);
        }

        public override void Break()
        {
            var block = Block as BrickBlock;
            block?.BreakIntoPieces();
        }

    }
}
