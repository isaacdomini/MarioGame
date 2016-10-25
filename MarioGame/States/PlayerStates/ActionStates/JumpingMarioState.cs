using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    class JumpingMarioState : MarioActionState
    {
        private float _jumpTimer = 0.0f;
        public JumpingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.JumpingMarioState);
            _mario.SetVelocityToJumping();
        }

        public override void End()//TODO: currently i dont think this method is getting called correctly. something with a null error about _prevState in state.Begin();
        {
            _jumpTimer = 0.0f;
        }
        public override void Fall()
        {
            base.Fall();
            stateMachine.FallingMarioState.Begin(this);
        }

        public override void Crouch()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
        public override void MoveRight()
        {
            if (_mario.FacingRight)
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            else
            {
                _mario.turnRight();
            }
        }
        public override void MoveLeft()
        {
            if (_mario.FacingLeft)
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            else
            {
                _mario.turnLeft();
            }
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            if (_jumpTimer > 1.5)
            {
                stateMachine.FallingMarioState.Begin(this);
                _jumpTimer = 0.0f; // todo make it so that the End() method correctly gets called so we don't have to do this.
            }
            else
            {
            _jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
