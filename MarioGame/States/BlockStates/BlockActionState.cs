using System;
using MarioGame.Entities;
using MarioGame.States.BlockStates;

namespace MarioGame.States
{
    public class BlockActionState : ActionState
    {
        protected BlockActionStateMachine StateMachine;
        public BlockActionStateEnum BState
        {
            get; protected set;
        }

        public BlockActionState(Block entity, BlockActionStateMachine stateMachine) : base(entity)
        {
            this.StateMachine = stateMachine;
        }

        public virtual void Bump() { }
        public virtual void Break() { }
        public virtual void ChangeToUsed() { }
        public virtual void ChangeToStandard() { }
    }
}

