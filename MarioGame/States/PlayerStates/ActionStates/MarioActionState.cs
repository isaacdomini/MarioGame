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
        protected Mario Mario => (Mario)Entity;
        protected MarioActionStateMachine StateMachine;

        public MarioActionState(Mario entity, MarioActionStateMachine stateMachine) : base(entity)
        {
            this.StateMachine = stateMachine;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Jump() {
            StateMachine.JumpingMarioState.Begin(this);
        }

        public virtual void MoveRight() {
            if (Mario.FacingLeft)
            {
                Mario.TurnRight();
            }
        }

        public virtual void MoveLeft() {
            if (Mario.FacingRight)
            {
                Mario.TurnLeft();
            }
        }

        public virtual void Fall()
        {
        }

        public virtual void Crouch() {
            StateMachine.CrouchingMarioState.Begin(this);
        }
        public void Halt()
        {
            StateMachine.IdleMarioState.Begin(this);
        }
    }
}
