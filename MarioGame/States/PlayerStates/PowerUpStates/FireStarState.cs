using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireStarState : MarioPowerUpState
    {
        public FireStarState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.SuperStar;

        }

    }
}
