using System;
using MarioGame.Entities;
using MarioGame.States.BlockStates;

namespace MarioGame.States
{
    public class BlockActionState : ActionState
    {
        private BlockActionStateMachine _stateMachine;
        protected BlockActionStateMachine StateMachine => _stateMachine;
        protected Block Block => (Block) Entity;
        public BlockActionStateEnum BState
        {
            get; protected set;
        }

        public BlockActionState(Block entity, BlockActionStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Bump() { }
        public virtual void Break() { }
        public virtual void ChangeToUsed() { }
        public virtual void ChangeToStandard() { }
    }
}

