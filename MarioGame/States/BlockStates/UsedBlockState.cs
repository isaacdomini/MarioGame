using MarioGame.Entities;

namespace MarioGame.States
{
    class UsedBlockState : BlockState
    {
        public UsedBlockState(Block entity, BlockStateMachine stateMachine) : base(entity, stateMachine)
        {
            bState = BlockStateEnum.UsedBlock;
        }
    }
}
