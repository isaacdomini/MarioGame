using MarioGame.Entities;

namespace MarioGame.States
{
    public class BlockActionState : ActionState
    {
        public BlockActionStateMachine actionState
        {
            get; protected set; //TODO: make this read from some shared enum with Sprites
        }
        protected Block block;
        protected BlockActionStateMachine stateMachine;

        public BlockActionState(Block entity, BlockActionStateMachine stateMachine) : base(entity)
        {
            block = entity;
            this.stateMachine = stateMachine;
        }

        public virtual void Begin(BlockActionState prevState)
        {
            base.Begin(prevState);
        }
    }
}

