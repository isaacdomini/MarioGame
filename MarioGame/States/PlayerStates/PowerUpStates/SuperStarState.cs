using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class SuperStarState : MarioPowerUpState
    {
        public SuperStarState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.SuperStar;

        }
    }
}
