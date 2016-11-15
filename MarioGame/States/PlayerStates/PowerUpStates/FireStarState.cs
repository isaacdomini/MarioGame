using MarioGame.Entities;

namespace MarioGame.States
{
    internal class FireStarState : MarioPowerUpState
    {
        public FireStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.FireStar;
        }
        public override void OnInvincibilityEnded()
        {
            Mario.ChangePowerUpState(StateMachine.FireState);
        }
        public override void DashOrThrowFireball()
        {
            Mario.ThrowFireball();
        }
    }
}
