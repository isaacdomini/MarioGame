using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class UsedBlockState : BlockState
    {
        public UsedBlockState(Block entity, BlockStateMachine stateMachine) : base(entity, stateMachine)
        {
            bState = BlockStateEnum.UsedBlock;
        }
    }
}
