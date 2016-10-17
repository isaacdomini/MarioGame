using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class BreakBlockState : BlockState
    {
        public BreakBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.BreakingBlock;
        }

        public override void Bump() { }
        public override void Standard() { }
        public override void Used() { }
        public override void Break() { }
    }
}
