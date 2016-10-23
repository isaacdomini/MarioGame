using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperStarState : MarioPowerUpState
    {
        public SuperStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.SuperStar;
        }
    }
}
