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
            ((Block)Entity).ChangeActionState(StateMachine.StepState);
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
        public override void ChangeToStep()
        {
            this.End();
            StateMachine.StepState.Begin(this);
        }
        public override void ChangeToGround()
        {
            this.End();
            StateMachine.GroundState.Begin(this);
        }
        public override void ChangeToQuestion()
        {
            this.End();
            StateMachine.QuestionState.Begin(this);
        }
    }
}
