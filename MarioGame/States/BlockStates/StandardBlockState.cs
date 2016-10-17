using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class StandardBlockState : BlockState
    {
        public StandardBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.StandardBlock;
        }

        public override void Bump()
        {
            BlockState bumpState = new BumpBlockState(_block);
            _block.ChangeBrickState(bumpState);
            bumpState.Begin(this);

        }
        public override void Standard(){}
        public override void Used(){}
        public override void Break()
        {
            BlockState breakState = new BreakBlockState(_block);
            _block.ChangeBrickState(breakState);
            breakState.Begin(this);
        }
    }
}
