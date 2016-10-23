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
        public virtual void Jump() { }

        public virtual void MoveRight() {
            if (_mario.isFacingLeft())  
            {
                _mario.turnRight();
                stateMachine.IdleMarioState.Begin(this);
            }
            else if (_mario.isFacingRight())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
        }

        public virtual void MoveLeft() {
            if (_mario.isFacingLeft())
            {
                stateMachine.WalkingMarioState.Begin(this);
            } else if (_mario.isFacingRight())
            {
                _mario.turnLeft();
                stateMachine.IdleMarioState.Begin(this);
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
