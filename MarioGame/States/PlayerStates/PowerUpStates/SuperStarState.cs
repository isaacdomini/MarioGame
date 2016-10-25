using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperStarState : MarioPowerUpState
    {
        public SuperStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.SuperStar;
        }
        public override void OnInvincibilityEnded()
        {
            Mario.ChangePowerUpState(StateMachine.StandardState);
        }
    }
}
