using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    class BlockState : StandardState
    {
        protected BlockStateEnum bState;

        protected Block
            _block;

        public BlockState(Block entity) : base(entity)
        {
            _block = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
    }
}
