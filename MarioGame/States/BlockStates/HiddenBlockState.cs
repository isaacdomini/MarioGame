using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.HiddenBlock;
        }

        public override void Bump() {
            Standard();
        }
        public override void Standard() {
            BlockState standardState = new StandardBlockState(_block);
            _block.ChangeBrickState(standardState);
            standardState.Begin(this);
        }
        public override void Used() { }
        public override void Break() { }
    }
}
