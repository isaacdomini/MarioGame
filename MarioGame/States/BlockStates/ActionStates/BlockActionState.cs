using MarioGame.Entities;

namespace MarioGame.States
{
    public class BlockActionState : ActionState
    {
        protected Block block;
        protected BlockActionStateMachine stateMachine;
        public BlockActionStateEnum bState
        {
            get; protected set;
        }

        public BlockActionState(Block entity, BlockActionStateMachine stateMachine) : base(entity)
        {
            block = entity;
            this.stateMachine = stateMachine;
        }

        public virtual void Bump() { }
        public virtual void Reveal() { }
        public virtual void Break() { }
        public virtual void ChangeToUsed() { }

    }
}

