using MarioGame.Entities;

namespace MarioGame.States
{
    class StandardStarState : MarioPowerUpState
    {
        public StandardStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.StandardStar;
        }
        public override void OnInvincibilityEnded()
        {
            Mario.ChangePowerUpState(StateMachine.StandardState);
        }
    }
}
