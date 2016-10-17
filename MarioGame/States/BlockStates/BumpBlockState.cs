using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class BumpBlockState : BlockState
    {
        public BumpBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.BumpBlock;
        }

        public override void Bump(){}
        public override void Standard()
        {
            BlockState standardState = new StandardBlockState(_block);
            _block.ChangeBrickState(standardState);
            standardState.Begin(this);
        }
        public override void Used()
        {
            BlockState usedState = new UsedBlockState(_block);
            _block.ChangeBrickState(usedState);
            usedState.Begin(this);
        }
        public override void Break(){}
    }
}
