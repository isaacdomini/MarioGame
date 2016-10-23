using MarioGame.Entities;

namespace MarioGame.States
{
    class FireStarState : MarioPowerUpState
    {
        public FireStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.FireStar;
        }
    }
}
