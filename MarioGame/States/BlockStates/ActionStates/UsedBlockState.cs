using MarioGame.Entities;

namespace MarioGame.States
{
    class UsedBlockState : BlockActionState
    {
        public UsedBlockState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            bState = BlockActionStateEnum.UsedBlock;
        }
        public override void Begin(BlockActionState prevState)
        {
            block.ChangeBlockActionState(stateMachine.UsedState);
        }
    }
}
