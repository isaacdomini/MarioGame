using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : MarioActionState
    {
        public IdleMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Idle;
        }

        public override void Jump()
        {
            MarioActionState jumpState = new JumpingMarioState(mario);
            jumpState.setDirection(this.direction);
            mario.ChangeActionState(jumpState);
            mario.SetVelocityToJumpingStraight();
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            if (mario.PowerUpState.powerUpState == MarioPowerUpStateEnum.Standard)
            {
                MarioActionState fallingState = new FallingMarioState(mario);
                fallingState.setDirection(this.direction);
                mario.ChangeActionState(fallingState);
                mario.SetVelocityToFalling();
                fallingState.Begin(this);
            }
            else
            {
                MarioActionState crouchState = new CrouchingMarioState(mario);
                crouchState.setDirection(this.direction);
                mario.ChangeActionState(crouchState);
                mario.SetVelocityToFalling();
                crouchState.Begin(this);
            }

        }
        public override void MoveLeft()
        {
            if (this.isFacingLeft())
            {
                MarioActionState moveLeft = new WalkingMarioState(mario);
                mario.ChangeActionState(moveLeft);
                moveLeft.setDirection(this.direction);
                mario.SetVelocityToWalk(Directions.Left);
                moveLeft.Begin(this);
            }
            else if (this.isFacingRight())
            {
                MarioActionState idleLeft = new IdleMarioState(mario);
                mario.ChangeActionState(idleLeft);
                idleLeft.turnLeft();
                mario.SetVelocityToIdle();
                idleLeft.Begin(this);
            }

        }
        public override void MoveRight()
        {
            // Meaning idle mario is already facing right
            if (this.isFacingRight())
            {
                // Mario state is set to walking right
                MarioActionState moveRight = new WalkingMarioState(mario);
                mario.ChangeActionState(moveRight);
                moveRight.turnRight();
                mario.SetVelocityToWalk(Directions.Right);
                moveRight.Begin(this);
            }
            // Meaning marion is facing left
            else if (this.isFacingLeft())
            {
                // Mario is idling facing the right
                MarioActionState idleLeft = new IdleMarioState(mario);
                mario.ChangeActionState(idleLeft);
                idleLeft.turnRight();
                mario.SetVelocityToIdle();
                idleLeft.Begin(this);
            }

        }
    }
}
