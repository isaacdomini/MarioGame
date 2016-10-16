using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class CrouchingMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public CrouchingMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Crouching;
        }
        public override void Jump()
        {
            MarioActionState newState = new IdleMarioState(mario);
            newState.setDirection(this.direction);
            mario.ChangeActionState(newState);
            mario.SetVelocityToIdle();
            newState.Begin(this);
        }
        public override void Crouch()
        {
            MarioActionState fallingState = new FallingMarioState(mario);
            fallingState.setDirection(this.direction);
            mario.ChangeActionState(fallingState);
            mario.SetVelocityToFalling();
            fallingState.Begin(this);
        }
    }
}
