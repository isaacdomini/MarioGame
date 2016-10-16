using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    class FallingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public FallingMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Crouching; // what sprite should we use for falling?
        }
        public override void Jump()
        {
            MarioActionState idleMario = new IdleMarioState(mario);
            idleMario.setDirection(this.direction);
            mario.ChangeActionState(idleMario);
            mario.SetVelocityToIdle();
            idleMario.Begin(this);
        }
        public override void MoveLeft()
        {
            if (this.isFacingRight())
            {
                MarioActionState fallingFacingLeft = new FallingMarioState(mario);
                mario.ChangeActionState(fallingFacingLeft);
                fallingFacingLeft.turnLeft();
                mario.setVelocity(Mario.fallingVelocity);
                fallingFacingLeft.Begin(this);
            }
            else if (this.isFacingLeft())
            {
                MarioActionState walkingLeft = new WalkingMarioState(mario);
                mario.ChangeActionState(walkingLeft);
                walkingLeft.turnLeft();
                mario.setVelocity(Mario.walkingLeftVelocity);
                walkingLeft.Begin(this);

            }
        }
        public override void MoveRight()
        {
            if (this.isFacingLeft())
            {
                MarioActionState fallingFacingRight = new FallingMarioState(mario);
                mario.ChangeActionState(fallingFacingRight);
                fallingFacingRight.turnRight();
                mario.setVelocity(Mario.fallingVelocity);
                fallingFacingRight.Begin(this);
            }
            else if (this.isFacingRight())
            {
                MarioActionState walkingRight = new WalkingMarioState(mario);
                mario.ChangeActionState(walkingRight);
                walkingRight.turnRight();
                mario.setVelocity(Mario.walkingRightVelocity);
                walkingRight.Begin(this);

            }
        }
    }
}
