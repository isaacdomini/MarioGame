using System;
using MarioGame.Entities;
using Microsoft.Xna.Framework;
using MarioGame.Theming;

namespace MarioGame.States
{
    public abstract class MarioActionState : ActionState
    {
        public MarioActionStateEnum actionState
        {
            get; protected set; //TODO: make this read from some shared enum with Sprites
        }
        protected Mario Mario => (Mario)Entity;
        private MarioActionStateMachine _stateMachine;
        protected MarioActionStateMachine StateMachine => _stateMachine;

        internal MarioActionState(Mario entity, MarioActionStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Jump() {
            StateMachine.JumpingMarioState.Begin(this);
        }
        public void CheckForLevelEdges()
        {
            if (Mario.Position.X < GlobalConstants.GridWidth||Mario.Position.X>Mario.LevelWidth)
            {
                Mario.Halt();
            }
        }

        public virtual void MoveLeft()
        {
            if (Mario.FacingRight)
            {
                Mario.TurnLeft();
            }
            else
            {
                Mario.SetXVelocity(Vector2.One * -1.75f);
            }
        }
        public virtual void MoveRight()
        {
            if (Mario.FacingLeft)
            {
                Mario.TurnRight();
            }
            else
            {
                Mario.SetXVelocity(Vector2.One * 1.75f);
            }
        }
        public virtual void Fall()
        {
        }

        public virtual void Crouch() {
            StateMachine.CrouchingMarioState.Begin(this);
        }
        public virtual void HitTopOfGreenPipe(Action<Mario> sceneTransport, bool greenPipeInversion) { }
        public virtual void HitBottomOfGreenPipe(Action<Mario> sceneTransport, bool greenPipeInversion) { }
        public void Halt()
        {
            StateMachine.IdleMarioState.Begin(this);
        }
        public override void UpdateEntity(int gametime)
        {
            if (Mario.Velocity.Y > .2f)
            {
                if(!Mario.MarioActionState.Equals(StateMachine.FallingMarioState) && !Mario.MarioActionState.Equals(StateMachine.CrouchingMarioState))
                    Mario.ChangeActionState(StateMachine.FallingMarioState);
            }
            else if (Mario.Velocity.Y < 0)
            {
                if (!Mario.MarioActionState.Equals(StateMachine.JumpingMarioState))
                    Mario.ChangeActionState(StateMachine.JumpingMarioState);
            }
            else if (Mario.Velocity.X < .001f && Mario.Velocity.X > -.001f)
            {
                if (!Mario.MarioActionState.Equals(StateMachine.CrouchingMarioState))
                    Mario.ChangeActionState(StateMachine.IdleMarioState);
            }
            else
            {
                if (!Mario.MarioActionState.Equals(StateMachine.WalkingMarioState))
                    Mario.ChangeActionState(StateMachine.IdleMarioState);
            }
        }
    }
}
