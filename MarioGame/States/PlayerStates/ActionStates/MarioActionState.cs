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
        protected Mario _mario { get { return (Mario)_entity; } }
        protected MarioActionStateMachine stateMachine;

        public MarioActionState(Mario entity, MarioActionStateMachine stateMachine) : base(entity)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Jump() {
            stateMachine.JumpingMarioState.Begin(this);
        }

        public virtual void MoveRight() {
            if (_mario.FacingLeft)
            {
                _mario.turnRight();
            }
        }

        public virtual void MoveLeft() {
            if (_mario.FacingRight)
            {
                _mario.turnLeft();
            }
        }

        public virtual void Crouch() {
            stateMachine.CrouchingMarioState.Begin(this);
        }
        public virtual void Fall() { _mario.jumpTimer = 0.0f; }
        public void Halt()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
    }
}
