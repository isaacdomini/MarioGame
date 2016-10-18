using MarioGame.Entities;

namespace MarioGame.States
{
    public class BlockState
    {
        protected BlockStateEnum bState;

        protected BlockState _prevBState;

        protected BlockActionStateMachine _stateMachine;

        protected Block _block;

        public BlockState(Block entity, BlockActionStateMachine stateMachine)
        {
            _block = entity;
            _stateMachine = stateMachine;
        }

        public virtual void Begin(BlockState prevState)
        {
            _prevBState = prevState;
        }
        public virtual void Bump() { }
        public virtual void Reveal() { }
        public virtual void Break() { }
        public virtual void ChangeToUsed() { }
    }
}
