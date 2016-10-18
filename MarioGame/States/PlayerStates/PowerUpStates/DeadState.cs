using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
            _mario.isCollidable = false;
        }
    }
}
