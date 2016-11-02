using MarioGame.Entities;
using MarioGame.States.BlockStates;

namespace MarioGame.States
{
    class UsedBlockState : BlockActionState
    {
        public UsedBlockState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            BState = BlockActionStateEnum.Used;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.UsedState);
        }
        public override void EndState()
        {
            base.EndState();
            PrevState = this;
        }
        public override void ChangeToUsed()
        {
            this.EndState();
            StateMachine.UsedState.Begin(this);
        }
    }
}
