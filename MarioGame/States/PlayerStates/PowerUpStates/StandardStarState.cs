using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class StandardStarState : MarioPowerUpState
    {
        public StandardStarState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.StandardStar;
        }
    }
}
