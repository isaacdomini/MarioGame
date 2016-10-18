using MarioGame.Entities;

namespace MarioGame.States.BlockStates
{
    public class BlockState
    {
        protected BlockStateEnum bState;

        protected BlockState _prevBState;

        protected BlockStateMachine _stateMachine;

        protected Block _block;

        public BlockState(Block entity, BlockStateMachine stateMachine)
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
