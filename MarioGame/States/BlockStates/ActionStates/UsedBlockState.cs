using MarioGame.Entities;

namespace MarioGame.States
{
    class UsedBlockState : BlockActionState
    {
        public UsedBlockState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            BState = BlockActionStateEnum.UsedBlock;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.UsedState);
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
