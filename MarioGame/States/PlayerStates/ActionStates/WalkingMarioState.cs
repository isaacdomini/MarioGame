using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    class WalkingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public WalkingMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Walking;
        }

        public override void Jump()
        {
            
            MarioActionState jumpState = new JumpingMarioState(mario);
            mario.ChangeActionState(jumpState);
            jumpState.setDirection(this.direction);
            if (this.isFacingLeft())
            {
                mario.setVelocity(mario.jumpingLeftVelocity);
            }
            else if (this.isFacingRight())
            {
                mario.setVelocity(mario.jumpingRightVelocity);
            }
            jumpState.Begin(this);

        }
        public override void Crouch()
        {
            MarioActionState crouchState = new CrouchingMarioState(mario);
            mario.ChangeActionState(crouchState);
            crouchState.setDirection(this.direction);
            mario.setVelocity(mario.idleVelocity);
            crouchState.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.isFacingRight())
            {
                MarioActionState idleRight = new IdleMarioState(mario);
                mario.ChangeActionState(idleRight);
                idleRight.turnRight();
                mario.setVelocity(mario.idleVelocity);
                idleRight.Begin(this);
            }

        }
        public override void MoveRight()
        {
            if (this.isFacingLeft())
            {
                MarioActionState idleLeft = new IdleMarioState(mario);
                mario.ChangeActionState(idleLeft);
                idleLeft.turnLeft();
                mario.setVelocity(mario.idleVelocity);
                idleLeft.Begin(this);
            }
        }
    }
}
