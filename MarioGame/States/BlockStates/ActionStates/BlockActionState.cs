using MarioGame.Entities;

namespace MarioGame.States
{
    public class BlockActionState : ActionState
    {
        protected Block Block;
        protected BlockActionStateMachine StateMachine;
        public BlockActionStateEnum BState
        {
            get; protected set;
        }

        public BlockActionState(Block entity, BlockActionStateMachine stateMachine) : base(entity)
        {
            Block = entity;
            this.StateMachine = stateMachine;
        }

        public virtual void Bump() { }
        public virtual void Reveal() { }
        public virtual void Break() { }
        public virtual void ChangeToUsed() { }

    }
}

