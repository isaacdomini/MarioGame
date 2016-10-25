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
            Block.ChangeBlockActionState(StateMachine.UsedState);
        }
    }
}
