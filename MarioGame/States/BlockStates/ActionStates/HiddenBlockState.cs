using MarioGame.Entities;

namespace MarioGame.States
{
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(Block entity, BlockStateMachine stateMachine) : base(entity, stateMachine)
        {
            bState = BlockStateEnum.HiddenBlock;
        }


        public override void Bump() {
            _block.Reveal();
        }
    }
}
