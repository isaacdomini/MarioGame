using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class JumpingMarioState : MarioActionState
    {
        private float _jumpTimer;
        public JumpingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
        public override void Begin(MarioActionState prevState)
        {
            Mario.ChangeActionState(StateMachine.JumpingMarioState);
            Mario.SetVelocityToJumping();
            _jumpTimer = .75f;
        }

        public override void EndState()//TODO: currently i dont think this method is getting called correctly. something with a null error about _prevState in state.Begin();
        {
        }
        public override void Fall()
        {
            base.Fall();
            StateMachine.FallingMarioState.Begin(this);
        }

        public override void Crouch()
        {
            StateMachine.IdleMarioState.Begin(this);
        }

        public override void UpdateEntity(int elapsedMilliseconds)
        {
            //base.UpdateEntity(gameTime);
            if (Mario.Velocity.Y > -.01f)
            {
                Mario.SetYVelocity(new Vector2(Mario.Velocity.X, .21f));
                Mario.ChangeActionState(StateMachine.FallingMarioState);
            }
            _jumpTimer -= .01f;
        }

        public override void Jump()
        {
            if (Mario.Velocity.Y < 0)
            {
                Mario.SetYVelocity(new Vector2(Mario.Velocity.X, MathHelper.Clamp(Mario.Velocity.Y - _jumpTimer, -2, 2)));
            }
        }
    }
}
