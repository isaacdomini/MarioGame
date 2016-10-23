using System;
using MarioGame.Entities;

namespace MarioGame.States
{
    public abstract class MarioActionState : ActionState
    {
        public MarioActionStateEnum actionState
        {
            get; protected set; //TODO: make this read from some shared enum with Sprites
        }
        protected Mario mario;
        protected MarioActionStateMachine stateMachine;

        public MarioActionState(Mario entity, MarioActionStateMachine stateMachine) : base(entity)
        {
            mario = entity;
            this.stateMachine = stateMachine;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Jump() { }

        public virtual void MoveRight() { }

        public virtual void MoveLeft() {
            if (mario.isFacingLeft())
            {

            }
        }

        public virtual void Crouch() { }
        public virtual void Fall() { }
        public void Halt()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
    }
}
