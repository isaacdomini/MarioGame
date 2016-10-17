using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class UsedBlockState : BlockState
    {
        public UsedBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.UsedBlock;
        }

        public override void Bump(){}
        public override void Standard(){}
        public override void Used(){}
        public override void Break(){}
    }
}
